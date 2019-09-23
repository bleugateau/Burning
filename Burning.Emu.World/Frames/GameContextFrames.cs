using Burning.Common.Entity;
using Burning.Common.Managers.Frame;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.DofusProtocol.Network.Types;
using Burning.DofusProtocol.Data.D2P;
using Burning.DofusProtocol.Data.D2P.Elements;
using System.IO.Compression;
using System.IO;
using FlatyBot.Common.IO;
using Org.BouncyCastle.Utilities.Zlib;
using System.Linq;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Game.PathFinder;
using System.Threading.Tasks;
using Burning.Emu.World.Game.World;

namespace Burning.Emu.World.Frames
{
    public class GameContextFrames : Frame
    {
        [PacketId(GameContextCreateRequestMessage.Id)]
        public void GameContextCreateRequestMessageFrame(WorldClient client, GameContextCreateRequestMessage gameContextCreateRequestMessage)
        {
            client.SendPacket(new GameContextDestroyMessage());
            client.SendPacket(new GameContextCreateMessage(1));
            client.SendPacket(new LifePointsRegenBeginMessage(5));
            client.SendPacket(new CurrentMapMessage(client.ActiveCharacter.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));
            client.SendPacket(new SetCharacterRestrictionsMessage(client.ActiveCharacter.Id, new ActorRestrictionsInformations()));

            client.SendPacket(new UpdateMapPlayersAgressableStatusMessage(new List<double>() {
                client.ActiveCharacter.Id
            }, new List<uint>() {
                0
            }));
        }

        [PacketId(MapInformationsRequestMessage.Id)]
        public void MapInformationsRequestMessageFrame(WorldClient client, MapInformationsRequestMessage mapInformationsRequestMessage)
        {
            var map = MapManager.Instance.GetMap(client.ActiveCharacter.MapId);
            List<InteractiveElement> interactiveElements = new List<InteractiveElement>();
            List<StatedElement> statedElements = new List<StatedElement>();
           
            List<uint> elementIds = new List<uint>();

            foreach (var layer in map.MapData.Layers)
            {
                foreach (var cell in layer.Cells)
                {
                    foreach (var element in cell.Elements)
                    {
                        if (element is GraphicalElement)
                        {
                            var loc = (GraphicalElement)element;
                            if (loc.Identifier != 0 && loc.ElementId != 0)
                            {
                                var ele = ElementsEleRepository.Instance.List.FirstOrDefault(x => x.GfxId == loc.ElementId);
                                if (ele != null)
                                {
                                    interactiveElements.Add(new InteractiveElement((uint)loc.Identifier, ele.TypeId, new List<InteractiveElementSkill>() { new InteractiveElementSkill(114, 123) }, new List<InteractiveElementSkill>(), true));
                                    statedElements.Add(new StatedElement((uint)loc.Identifier, (uint)loc.Cell.CellId, (uint)2, true));
                                }
                            }
                        }
                    }
                }
            }

            //
            List<GameRolePlayActorInformations> gameRolePlayActorInformations = new List<GameRolePlayActorInformations>();
            foreach(var otherCharacter in WorldManager.Instance.worldClients.FindAll(x => x.ActiveCharacter != null && x.ActiveCharacter.MapId == client.ActiveCharacter.MapId))
            {
                gameRolePlayActorInformations.Add(otherCharacter.ActiveCharacter.GetGameRolePlayCharacterInformations());
                otherCharacter.SendPacket(new GameRolePlayShowActorMessage(client.ActiveCharacter.GetGameRolePlayCharacterInformations()));
            }

            gameRolePlayActorInformations.Add(client.ActiveCharacter.GetGameRolePlayCharacterInformations());

            List<GameRolePlayActorInformations> gameRolePlayNpcs = new List<GameRolePlayActorInformations>();
            foreach(var npc in map.NpcSpawnList)
            {
                gameRolePlayNpcs.Add(new GameRolePlayNpcInformations(npc.Id * -1, new EntityDispositionInformations(npc.CellId, (uint)npc.Orientation), Look.Parse(npc.EntityLook).GetEntityLook(), (uint)npc.NpcId, true, 1));
            }

            client.SendPacket(new MapComplementaryInformationsDataMessage((uint)map.MapData.SubAreaId, client.ActiveCharacter.MapId, new List<HouseInformations>(), gameRolePlayActorInformations, interactiveElements,
                statedElements, new List<MapObstacle>(), new List<FightCommonInformations>(), true, new FightStartingPositions()));

            client.SendPacket(new GameRolePlayShowMultipleActorsMessage(gameRolePlayNpcs));
            client.SendPacket(new SetCharacterRestrictionsMessage(client.ActiveCharacter.Id, new ActorRestrictionsInformations()));
        }

        [PacketId(GameMapMovementRequestMessage.Id)]
        public void GameMapMovementRequestMessageFrame(WorldClient client, GameMapMovementRequestMessage gameMapMovementRequestMessage)
        {
            var map = MapManager.Instance.GetMap(client.ActiveCharacter.MapId);

            Pathfinder pathfinder = new Pathfinder(new int[] { });
            pathfinder.SetMap(map.MapData, true);

            int cellId = MapManager.Instance.GetCellIdFromKeyMovement((int)gameMapMovementRequestMessage.keyMovements[gameMapMovementRequestMessage.keyMovements.Count - 1]);
            if (!pathfinder.IsValidPathfinding(client.ActiveCharacter, gameMapMovementRequestMessage.keyMovements))
            {
                client.SendPacket(new GameMapMovementCancelMessage((uint)cellId));
                return;
            }

            foreach (var otherClients in WorldManager.Instance.GetNearestClientsFromCharacter(client.ActiveCharacter))
            {
                otherClients.SendPacket(new GameMapMovementMessage(gameMapMovementRequestMessage.keyMovements, 2, client.ActiveCharacter.Id));
            }

            client.ActiveCharacter.CellId = cellId;
        }

        [PacketId(ChangeMapMessage.Id)]
        public void ChangeMapMessageFrame(WorldClient client, ChangeMapMessage changeMapMessage)
        {
            int mapId = (int)changeMapMessage.mapId;
            MapTransition replacedMap = MapTransitionsRepository.Instance.List.Find(x => x.mapIdRequested == changeMapMessage.mapId && x.fromNeighbour == (MapManager.Instance.GetMapNeighbourTransitionEnumFromCell(client.ActiveCharacter.CellId)));

            if (replacedMap != null)
                mapId = replacedMap.mapIdReplaced;

            var map = MapManager.Instance.GetMap(mapId);

            if (!MapManager.Instance.CheckIfNextMapIsValid(client.ActiveCharacter.MapId, mapId, client.ActiveCharacter.CellId))
                return;

            if (map != null)
            {
                foreach (var otherClients in WorldManager.Instance.GetNearestClientsFromCharacter(client.ActiveCharacter))
                {
                    otherClients.SendPacket(new GameContextRemoveElementMessage(client.ActiveCharacter.Id));
                }

                client.SendPacket(new GameContextDestroyMessage());
                client.SendPacket(new GameContextCreateMessage(1));

                client.ActiveCharacter.MapId = mapId;
                client.SendPacket(new CurrentMapMessage(client.ActiveCharacter.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));

                client.ActiveCharacter.CellId = MapManager.Instance.CheckWalkableCell(mapId, MapManager.Instance.GetOppositeCellFromNeight(client.ActiveCharacter.CellId));
            }
        }
    }
}
