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
            client.SendPacket(new GameContextDestroyMessage());
            client.SendPacket(new GameContextCreateMessage(2));
            client.SendPacket(new CharacterStatsListMessage(client.ActiveCharacter.GetCharacterCharacteristicsInformations()));
            client.SendPacket(new GameFightStartingMessage((uint)FightTypeEnum.FIGHT_TYPE_PvM, 1, gameRolePlayAttackMonsterRequestMessage.monsterGroupId, (double)client.ActiveCharacter.Id));

            var map = MapManager.Instance.GetMap(client.ActiveCharacter.MapId);
            var monstergroup = map.MonstersGroups.Find(x => x.Id == (int)gameRolePlayAttackMonsterRequestMessage.monsterGroupId);

            if (monstergroup == null)
                return;

            client.SendPacket(new GameFightJoinMessage(true, false, true, false, 450, (uint)FightTypeEnum.FIGHT_TYPE_PvM));
            client.SendPacket(new GameFightPlacementPossiblePositionsMessage(map.FightStartingPosition.positionsForChallengers, map.FightStartingPosition.positionsForDefenders, 0));

            //Add monster to Defenders
            List<Fighter> monsters = new List<Fighter>();
            foreach(var monster in monstergroup.Monsters)
            {
                var cellUsed = monsters.Select(x => (uint)x.CellId).ToList();
                var cellPlacementId = map.FightStartingPosition.positionsForDefenders.Find(x => !cellUsed.Contains(x));

                //check dans fighters la cell utilisé
                if(cellPlacementId != 0)
                    monsters.Add(new MonsterFighter(monster, (int)cellPlacementId)); //ajout des monstres
            }

            //add characters to challengers
            List<Fighter> characters = new List<Fighter>();
            characters.Add(new CharacterFighter(client.ActiveCharacter, (int)map.FightStartingPosition.positionsForChallengers[0])); //ajout du character

            //add fight to fightmanager
            var fight = new Fight(client.ActiveCharacter.MapId, FightTypeEnum.FIGHT_TYPE_PvM, monsters, characters, map.FightStartingPosition);
            FightManager.Instance.Fights.Add(fight);
            fight.EnterFight(client); //enter into fight
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
    }
}
