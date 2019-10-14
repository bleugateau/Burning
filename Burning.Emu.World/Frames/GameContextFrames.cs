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
using System.Linq;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Game.PathFinder;
using System.Threading.Tasks;
using Burning.Emu.World.Game.World;
using Burning.Emu.World.Repository;
using Burning.Emu.World.Game.Fight.Fighters;

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

            //quand joueur entre sur la carte
            map.EnterMap(client);

            List<GameRolePlayActorInformations> gameRolePlayActorInformations = map.GetGameRolePlayActorInformations(client);

            //npc
            List<GameRolePlayActorInformations> gameRolePlayNpcs = new List<GameRolePlayActorInformations>();
            foreach(var npc in map.NpcSpawnList)
            {
                gameRolePlayNpcs.Add(new GameRolePlayNpcInformations(npc.Id * -1, new EntityDispositionInformations(npc.CellId, (uint)npc.Orientation), Look.Parse(npc.EntityLook).GetEntityLook(), (uint)npc.NpcId, true, 1));
            }

            //monsters
            foreach(var monsterGroup in map.MonstersGroups)
            {
                gameRolePlayNpcs.Add(monsterGroup.RolePlayGroupMonsterInformations);
            }

            client.SendPacket(new MapComplementaryInformationsDataMessage((uint)map.MapData.SubAreaId, client.ActiveCharacter.MapId, new List<HouseInformations>(), gameRolePlayActorInformations, interactiveElements,
                statedElements, new List<MapObstacle>(), new List<FightCommonInformations>(), true, map.FightStartingPosition));

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

            var fight = client.ActiveCharacter.Fight;

            if (fight != null) //si le joueur est dans un fight
            {
                if(fight.ActualFighter is CharacterFighter && fight.ActualFighter.Id == client.ActiveCharacter.Id)
                    fight.MovementRequestSequence(cellId);
            }
            else
            {

                map.SendGameMapMovementMessage(gameMapMovementRequestMessage.keyMovements, client);

                client.ActiveCharacter.CellId = cellId;
                CharacterRepository.Instance.Update(client.ActiveCharacter);
            }
            
        }

        [PacketId(ChangeMapMessage.Id)]
        public void ChangeMapMessageFrame(WorldClient client, ChangeMapMessage changeMapMessage)
        {
            int mapId = (int)changeMapMessage.mapId;
            MapTransition replacedMap = MapTransitionsRepository.Instance.GetTransitionFromMapId((int)changeMapMessage.mapId, (int)MapManager.Instance.GetMapNeighbourTransitionEnumFromCell(client.ActiveCharacter.CellId));

            if (replacedMap != null)
                mapId = replacedMap.MapIdReplaced;

            if (!MapManager.Instance.CheckIfNextMapIsValid(client.ActiveCharacter.MapId, mapId, client.ActiveCharacter.CellId))
                return;

            var oldMap = MapManager.Instance.GetMap(client.ActiveCharacter.MapId);
            var map = MapManager.Instance.GetMap(mapId);


            if (map != null)
            {
                oldMap.ExitMap(client);

                client.SendPacket(new GameContextDestroyMessage());
                client.SendPacket(new GameContextCreateMessage(1));

                client.ActiveCharacter.MapId = mapId;
                client.SendPacket(new CurrentMapMessage(client.ActiveCharacter.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));

                client.ActiveCharacter.CellId = MapManager.Instance.CheckWalkableCell(map, MapManager.Instance.GetOppositeCellFromNeight(client.ActiveCharacter.CellId));

                CharacterRepository.Instance.Update(client.ActiveCharacter);
            }
        }
    }
}
