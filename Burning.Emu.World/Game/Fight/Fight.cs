using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Game.Fight.Fighters;
using Burning.Emu.World.Game.World;
using Burning.Emu.World.Network;

namespace Burning.Emu.World.Game.Fight
{
    public class Fight
    {
        public int Id { get; set; }

        public Fighter ActualFighter { get; set; }

        public List<Fighter> Defenders { get; set; }

        public List<Fighter> Challengers { get; set; }

        public FightTypeEnum FightType { get; set; }

        public FightStartingPositions FightStartingPositions { get; set; }

        public FightStateEnum FightState { get; set; }

        public List<WorldClient> clientsInFight { get; set; }

        public int Round { get; set; }

        private Timer TurnTimer { get; set; }

        private Timer PlacementPhaseTimer { get; set; }

        public Fight(FightTypeEnum type, List<Fighter> defenders, List<Fighter> challengers, FightStartingPositions fightStartingPositions)
        {
            this.Id = 1; //Uniqid a faire
            this.FightType = type;
            this.Defenders = defenders;
            this.Challengers = challengers;
            this.FightStartingPositions = fightStartingPositions;
            this.FightState = FightStateEnum.FIGHT_CHOICE_PLACEMENT;
            this.Round = 0;

            this.StartPlacementPhaseTimer();
        }

        public void EnterFight(WorldClient client)
        {
            foreach (var fighter in this.Challengers.Concat(this.Defenders))
            {
                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)fighter.CellId, 1, fighter.Id);
                client.SendPacket(new GameEntitiesDispositionMessage(new List<IdentifiedEntityDispositionInformations>() { identifiedEntityDispositionInformations }));

                if (fighter is CharacterFighter)
                    client.SendPacket(new GameFightShowFighterMessage(((CharacterFighter)fighter).GetGameFightCharacterInformations()));
                else if (fighter is MonsterFighter)
                    client.SendPacket(new GameFightShowFighterMessage(((MonsterFighter)fighter).GetGameFightMonsterInformations()));
            }
        }

        public bool CanChangeStartingPositions(WorldClient client, int requestedCellId)
        {

            if (this.FightState != FightStateEnum.FIGHT_CHOICE_PLACEMENT)
                return false;

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
            foreach (var fighter in this.Challengers.Concat(this.Defenders))
            {
                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)fighter.CellId, 1, fighter.Id);
                dispositions.Add(identifiedEntityDispositionInformations);
            }

            //update position
            client.SendPacket(new GameEntitiesDispositionMessage(dispositions));

            return true;
        }

        public void StartPlacementPhaseTimer()
        {
            if (this.FightState != FightStateEnum.FIGHT_CHOICE_PLACEMENT)
                return;

            PlacementPhaseTimer = new Timer(45000);
            PlacementPhaseTimer.Elapsed += Timer_Elapsed;
            PlacementPhaseTimer.Enabled = true;
        }

        public void StartTurnTimer(int millisecondes)
        {
            if (this.FightState != FightStateEnum.FIGHT_STARTED)
                return;

            TurnTimer = new Timer(millisecondes * 100);
            TurnTimer.Elapsed += Timer_Elapsed;
            TurnTimer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            switch(this.FightState)
            {
                case FightStateEnum.FIGHT_CHOICE_PLACEMENT:
                    //actualise l'ordre dans la timeline
                    var orderedFighters = this.Challengers.Concat(this.Defenders).OrderBy(x => x.Initiative).ToList();
                    for(int i = 0; i < orderedFighters.Count; i++)
                    {
                        orderedFighters[i].TimelineOrder = (i + 1);
                    }

                    foreach (var fighter in this.Challengers.Concat(this.Defenders).ToList().FindAll(x => x is CharacterFighter))
                    {
                        var client = WorldManager.Instance.GetClientFromCharacter(((CharacterFighter)fighter).Character);
                        if (client != null)
                            client.SendPacket(new GameFightTurnStartMessage(orderedFighters[0].Id, 320));
                    }

                    this.ActualFighter = orderedFighters[0];
                    this.Round = 1;
                    this.FightState = FightStateEnum.FIGHT_STARTED;
                    this.StartTurnTimer(50);
                    PlacementPhaseTimer.Stop();
                    break;
                case FightStateEnum.FIGHT_STARTED:
                    //todo faire une fonction qui turnEnd
                    TurnTimer.Stop();

                    var aliveFighters = this.Challengers.Concat(this.Defenders).OrderBy(x => x.TimelineOrder).ToList().FindAll(x => x.Life > 0);
                    var nextFighter = this.Challengers.Concat(this.Defenders).OrderBy(x => x.TimelineOrder).ToList().Find(x => x.TimelineOrder > this.ActualFighter.TimelineOrder && x.Life > 0);

                    if (nextFighter == null)
                    {
                        if (aliveFighters.Count > 1)
                        {
                            this.ActualFighter = this.Challengers.Concat(this.Defenders).OrderBy(x => x.TimelineOrder).ToList().First();
                        }
                        else
                        {
                            Console.WriteLine("Fin du combat !");
                            return;
                        }
                    }
                    else
                    {
                        this.ActualFighter = nextFighter;
                    }

                    Console.WriteLine("FIN DU TOUR DE JEU");
                    Console.WriteLine("NOUVEAU TOUR POUR {0} authorId.", this.ActualFighter.Id);

                    this.StartTurnTimer(50);
                    break;
            }
        }
    }
}
