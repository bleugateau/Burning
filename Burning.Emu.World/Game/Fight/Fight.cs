using System;
using System.Collections.Generic;
using System.Text;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Game.Fight.Fighters;
using Burning.Emu.World.Network;

namespace Burning.Emu.World.Game.Fight
{
    public class Fight
    {
        public int Id { get; set; }

        public List<Fighter> Defenders { get; set; }

        public List<Fighter> Challengers { get; set; }

        public FightTypeEnum FightType { get; set; }

        public FightStartingPositions FightStartingPositions { get; set; }

        public int Round { get; set; }

        public Fight(FightTypeEnum type, List<Fighter> defenders, List<Fighter> challengers, FightStartingPositions fightStartingPositions)
        {
            this.Id = 1; //Uniqid a faire
            this.FightType = type;
            this.Defenders = defenders;
            this.Challengers = challengers;
            this.FightStartingPositions = fightStartingPositions;
            this.Round = 0;
        }

        public void EnterFight(WorldClient client)
        {
            foreach (var challenger in this.Challengers)
            {
                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)challenger.CellId, 1, challenger.Id);
                client.SendPacket(new GameEntitiesDispositionMessage(new List<IdentifiedEntityDispositionInformations>() { identifiedEntityDispositionInformations }));

                if (challenger is CharacterFighter)
                    client.SendPacket(new GameFightShowFighterMessage(((CharacterFighter)challenger).GetGameFightCharacterInformations()));
            }

            foreach (var defender in this.Defenders)
            {
                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)defender.CellId, 1, defender.Id);
                client.SendPacket(new GameEntitiesDispositionMessage(new List<IdentifiedEntityDispositionInformations>() { identifiedEntityDispositionInformations }));

                if(defender is MonsterFighter)
                    client.SendPacket(new GameFightShowFighterMessage(((MonsterFighter)defender).GetGameFightMonsterInformations()));
            }
        }

        public bool CanChangeStartingPositions(WorldClient client, int requestedCellId)
        {
            bool isDefender = this.Defenders.Find(x => x is CharacterFighter && x.Id == client.ActiveCharacter.Id) != null ? true : false;

            if(isDefender)
            {
                bool isStartingPos = this.FightStartingPositions.positionsForDefenders.Find(x => x == requestedCellId) != 0 ? true : false;
                if (!isStartingPos)
                    return false;

                bool isFreeCell = this.Defenders.Find(x => x.CellId == requestedCellId) != null ? true : false;
                if (isFreeCell)
                    return false;

                //update cellid
                this.Defenders.Find(x => x is CharacterFighter && x.Id == client.ActiveCharacter.Id).CellId = requestedCellId;
            }
            else
            {
                bool isStartingPos = this.FightStartingPositions.positionsForChallengers.Find(x => x == requestedCellId) != 0 ? true : false;
                if (!isStartingPos)
                    return false;

                bool isFreeCell = this.Challengers.Find(x => x.CellId == requestedCellId) != null ? true : false;
                if (isFreeCell)
                    return false;

                //update cellid
                this.Challengers.Find(x => x is CharacterFighter && x.Id == client.ActiveCharacter.Id).CellId = requestedCellId;
            }

            List<IdentifiedEntityDispositionInformations> dispositions = new List<IdentifiedEntityDispositionInformations>();
            foreach (var challenger in this.Challengers)
            {
                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)challenger.CellId, 1, challenger.Id);
                dispositions.Add(identifiedEntityDispositionInformations);
            }

            foreach (var defender in this.Defenders)
            {
                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)defender.CellId, 1, defender.Id);
                dispositions.Add(identifiedEntityDispositionInformations);
            }

            //update position
            client.SendPacket(new GameEntitiesDispositionMessage(dispositions));

            return true;
        }
    }
}
