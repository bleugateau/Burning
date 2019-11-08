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
using Burning.DofusProtocol.Datacenter;
using Burning.Emu.World.Game.Interactive;

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

            // interative elements
            List<InteractiveElement> interactiveElements = new List<InteractiveElement>();
            foreach (var iElement in map.InteractiveElementList)
            {

                InteractiveElement interactiveElement = new InteractiveElement((uint)iElement.ElementId, iElement.TypeId, new List<InteractiveElementSkill>() { new InteractiveElementSkill((uint)iElement.SkillId, 0) }, new List<InteractiveElementSkill>(), true);
                /*
                if(iElement.TypeId == 43)
                {
                    interactiveElement = new InteractiveElementWithAgeBonus((uint)iElement.ElementId, iElement.TypeId, new List<InteractiveElementSkill>() { new InteractiveElementSkill((uint)iElement.SkillId, 0) }, new List<InteractiveElementSkill>(), true, 0);
                }*/

                

                interactiveElements.Add(interactiveElement);
            }

            

            // stated elements
            List<StatedElement> statedElements = new List<StatedElement>();
            foreach (var sElement in map.StatedElementList)
            {
                StatedElement statedElement = new StatedElement();
                statedElement.elementCellId = (uint)sElement.CellId;
                statedElement.elementId = (uint)sElement.ElementId;
                statedElement.elementState = 0;
                statedElement.onCurrentMap = true;

                statedElements.Add(statedElement);
            }


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
                statedElements, new List<MapObstacle>(), map.GetFightInformationsOnMap(), true, map.FightStartingPosition));

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

        [PacketId(InteractiveUseRequestMessage.Id)]
        public void InteractiveUseRequestMessageFrame(WorldClient client, InteractiveUseRequestMessage interactiveUseRequestMessage)
        {
            InteractiveManager.Instance.Dispatch(114, client);
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

        [PacketId(NpcGenericActionRequestMessage.Id)]
        public void NpcGenericActionRequestMessageFrame(WorldClient client, NpcGenericActionRequestMessage npcGenericActionRequestMessage)
        {
            var npcsSpawn = NpcSpawnRepository.Instance.GetNpcSpawnsFromMapId(client.ActiveCharacter.MapId);

            if (npcsSpawn.Count == 0)
                return;

            var npcSpawn = npcsSpawn.Find(x => x.Id == npcGenericActionRequestMessage.npcId * -1);

            var npc = NpcRepository.Instance.GetNpcFromId(npcSpawn != null ? npcSpawn.NpcId : 0);

            if (npc == null)
                return;

            client.SendPacket(new NpcDialogCreationMessage(client.ActiveCharacter.MapId, npcGenericActionRequestMessage.npcId));

            KeyValuePair<int, List<uint>> messageNpc = ExperimentalFindMessageId(npc);

            
            client.SendPacket(new NpcDialogQuestionMessage((uint)messageNpc.Key, new List<string>(), messageNpc.Value));

        }

        public KeyValuePair<int, List<uint>> ExperimentalFindMessageId(Npc npc)
        {
            int result = npc.DialogMessages.Count != 0 ? npc.DialogMessages[0][0] : 0;
            List<uint> replies = new List<uint>();

            for (int i = 0; i < npc.DialogMessages.Count; i++)
            {
                var npcReplies = npc.DialogReplies.Where(x => x[0] > npc.DialogMessages[i][0] && (i != npc.DialogMessages.Count - 1 ? x[0] < npc.DialogMessages[i + 1][0] : false)).Select(x => (uint)x[0]);


                if (npc.DialogMessages[i][0] == 20780)
                {
                    Console.WriteLine("NPC MESSAGE ID: 20780");
                    Console.WriteLine("NPC NEXT MESSAGE ID: {0}.", npc.DialogMessages[i + 1][0]);
                }

                if (npcReplies.Count() != 0 && npcReplies.Count() < 5)
                {
                    result = npc.DialogMessages[i][0];
                    replies = npcReplies.ToList();
                    break;
                }
            }

            return new KeyValuePair<int, List<uint>>(result, replies);
        }
    }
}
