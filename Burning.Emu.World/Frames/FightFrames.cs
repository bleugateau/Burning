using Burning.Common.Managers.Frame;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.Emu.World.Network;
using Burning.Emu.World.Game.Fight;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Game.Fight.Fighters;
using System.Linq;

namespace Burning.Emu.World.Frames
{
    public class FightFrames : Frame
    {
        [PacketId(GameRolePlayAttackMonsterRequestMessage.Id)]
        public void GameRolePlayAttackMonsterRequestMessageFrame(WorldClient client, GameRolePlayAttackMonsterRequestMessage gameRolePlayAttackMonsterRequestMessage)
        {

            var map = MapManager.Instance.GetMap(client.ActiveCharacter.MapId);

            if (map == null)
                return;

            var monstergroup = map.MonstersGroups.Find(x => x.Id == (int)gameRolePlayAttackMonsterRequestMessage.monsterGroupId);

            if (monstergroup == null)
                return;

            if (client.ActiveCharacter.CellId != monstergroup.RolePlayGroupMonsterInformations.disposition.cellId)
                return;
                

            client.SendPacket(new GameContextDestroyMessage());
            client.SendPacket(new GameContextCreateMessage(2));
            client.SendPacket(new CharacterStatsListMessage(client.ActiveCharacter.GetCharacterCharacteristicsInformations()));
            client.SendPacket(new GameFightStartingMessage((uint)FightTypeEnum.FIGHT_TYPE_PvM, 1, (double)client.ActiveCharacter.Id, gameRolePlayAttackMonsterRequestMessage.monsterGroupId));


            client.SendPacket(new GameFightJoinMessage(true, false, true, false, 450, (uint)FightTypeEnum.FIGHT_TYPE_PvM));
            client.SendPacket(new GameFightPlacementPossiblePositionsMessage(map.FightStartingPosition.positionsForChallengers, map.FightStartingPosition.positionsForDefenders, 0));

            //Add monster to Defenders
            List<Fighter> monsters = new List<Fighter>();
            foreach (var monster in monstergroup.Monsters)
            {
                var cellUsed = monsters.Select(x => (uint)x.CellId).ToList();
                var cellPlacementId = map.FightStartingPosition.positionsForDefenders.Find(x => !cellUsed.Contains(x));

                //check dans fighters la cell utilisé
                if (cellPlacementId != 0)
                    monsters.Add(new MonsterFighter(TeamEnum.TEAM_DEFENDER, monster, (int)cellPlacementId)); //ajout des monstres
            }

            //on enléve le monster group
            map.RemoveMonsterGroup(client, monstergroup);

            //add characters to challengers
            List<Fighter> characters = new List<Fighter>();
            characters.Add(new CharacterFighter(TeamEnum.TEAM_CHALLENGER, client.ActiveCharacter, (int)map.FightStartingPosition.positionsForChallengers[0])); //ajout du character

            //add fight to fightmanager
            var fight = new Fight(map, FightTypeEnum.FIGHT_TYPE_PvM, monsters, characters, map.FightStartingPosition);
            FightManager.Instance.Fights.Add(fight);
            
            fight.UpdateFightersDispositionInformations(client);

            //ajout du fight sur la map
            map.AddFight(client, fight);
        }

        [PacketId(GameFightJoinRequestMessage.Id)]
        public void GameFightJoinRequestMessageFrame(WorldClient client, GameFightJoinRequestMessage gameFightJoinRequestMessage)
        {
            var map = MapManager.Instance.GetMap(client.ActiveCharacter.MapId);

            if (map == null)
                return;

            var fight = map.GetFight((int)gameFightJoinRequestMessage.fightId);

            if (fight == null)
                return;

            fight.EnterFight(client);
        }

        [PacketId(GameFightPlacementPositionRequestMessage.Id)]
        public void GameFightPlacementPositionRequestMessageFrame(WorldClient client, GameFightPlacementPositionRequestMessage gameFightPlacementPositionRequestMessage)
        {
            var fight = client.ActiveCharacter.Fight;

            if (fight == null)
                return;

            if (!fight.CanChangeStartingPositions(client, (int)gameFightPlacementPositionRequestMessage.cellId))
                return;
        }

        [PacketId(GameFightTurnFinishMessage.Id)]
        public void GameFightTurnFinishMessageFrame(WorldClient client, GameFightTurnFinishMessage gameFightTurnFinishMessage)
        {
            var fight = client.ActiveCharacter.Fight;

            if (fight == null)
                return;

            if (fight.ActualFighter is CharacterFighter && fight.ActualFighter.Id == client.ActiveCharacter.Id)
                fight.TurnEnd();
        }

        [PacketId(GameActionFightCastRequestMessage.Id)]
        public void GameActionFightCastRequestMessageFrame(WorldClient client, GameActionFightCastRequestMessage gameActionFightCastRequestMessage)
        {
            var fight = client.ActiveCharacter.Fight;

            if (fight == null)
                return;

            if (fight.ActualFighter is CharacterFighter && fight.ActualFighter.Id == client.ActiveCharacter.Id)
                fight.CastSpellRequestSequence(gameActionFightCastRequestMessage.cellId, (int)gameActionFightCastRequestMessage.spellId);
        }
    }
}
