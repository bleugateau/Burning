using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using Burning.Common.Repository;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Game.Fight.Brain;
using Burning.Emu.World.Game.Fight.Effects;
using Burning.Emu.World.Game.Fight.Fighters;
using Burning.Emu.World.Game.Fight.Spell;
using Burning.Emu.World.Game.Level;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Game.PathFinder;
using Burning.Emu.World.Game.Shapes;
using Burning.Emu.World.Game.Shapes.Zones;
using Burning.Emu.World.Game.World;
using Burning.Emu.World.Network;
using Burning.Emu.World.Repository;
using FlatyBot.Common.Network;

namespace Burning.Emu.World.Game.Fight
{
    public class Fight
    {
        public int Id { get; set; }

        public Map.Map Map { get; set; }

        public Fighter ActualFighter { get; set; }

        public List<Fighter> Defenders { get; set; }

        public List<Fighter> Challengers { get; set; }

        public FightTypeEnum FightType { get; set; }

        public FightStartingPositions FightStartingPositions { get; set; }

        public FightStateEnum FightState { get; set; }

        public int Round { get; set; }

        public List<Fighter> Fighters
        {
            get
            {
                return this.Defenders.Concat(this.Challengers).ToList();
            }
        }

        private Timer TurnTimer { get; set; }

        private Timer PlacementPhaseTimer { get; set; }

        private Stopwatch ElapsdedTime { get; set; }

        private TeamEnum TeamWinner { get; set; }

        private readonly object locker = new object();

        public Fight(Map.Map map, FightTypeEnum type, List<Fighter> defenders, List<Fighter> challengers, FightStartingPositions fightStartingPositions)
        {
            this.Id = (int)(DateTime.Now.Ticks + new Random().Next(1, 99999)); //Uniqid a faire
            this.Map = map;
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
            if (this.FightState != FightStateEnum.FIGHT_CHOICE_PLACEMENT)
                return;

            lock (locker)
            {
                uint freeCellId = this.FightStartingPositions.positionsForChallengers.Find(x => !this.Challengers.Select(c => (uint)c.CellId).Contains(x));

                if (freeCellId == 0)
                    return;


                client.SendPacket(new GameContextDestroyMessage());
                client.SendPacket(new GameContextCreateMessage(2));

                client.SendPacket(new CharacterStatsListMessage(client.ActiveCharacter.GetCharacterCharacteristicsInformations()));

                client.SendPacket(new GameFightStartingMessage((uint)this.FightType, (uint)this.Id, this.Challengers[0].Id, this.Defenders[0].Id));
                client.SendPacket(new GameFightJoinMessage(true, false, true, false, 450, (uint)FightTypeEnum.FIGHT_TYPE_PvM));
                client.SendPacket(new GameFightPlacementPossiblePositionsMessage(this.Map.FightStartingPosition.positionsForChallengers, this.Map.FightStartingPosition.positionsForDefenders, 0));

                var newFighter = new CharacterFighter(TeamEnum.TEAM_CHALLENGER, client.ActiveCharacter, (int)freeCellId);

                this.Challengers.Add(newFighter);

                //envoie au autres fighter le nouveau fighter
                this.SendFighterDispositionInformations(newFighter);

            }

            //envoie la list des fighters déjà présent dans mon fight
            this.UpdateFightersDispositionInformations(client);
        }

        public void SendFighterDispositionInformations(CharacterFighter newFighter)
        {
            foreach (var fighter in this.Fighters.Where(x => x is CharacterFighter))
            {

                var characterFighter = (CharacterFighter)fighter;

                var fighterClient = this.Map.GetClientFromCharacter(characterFighter.Character);

                if (fighterClient == null)
                    continue;

                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)newFighter.CellId, 1, (double)newFighter.Id);
                fighterClient.SendPacket(new GameEntitiesDispositionMessage(new List<IdentifiedEntityDispositionInformations>() { identifiedEntityDispositionInformations }));

                if (fighter is CharacterFighter)
                    fighterClient.SendPacket(new GameFightShowFighterMessage(newFighter.GetGameFightCharacterInformations()));
            }
        }

        public void UpdateFightersDispositionInformations(WorldClient client)
        {
            foreach (var fighter in this.Challengers.Concat(this.Defenders))
            {
                IdentifiedEntityDispositionInformations identifiedEntityDispositionInformations = new IdentifiedEntityDispositionInformations((int)fighter.CellId, 1, (double)fighter.Id);
                client.SendPacket(new GameEntitiesDispositionMessage(new List<IdentifiedEntityDispositionInformations>() { identifiedEntityDispositionInformations }));

                switch(fighter)
                {
                    case CharacterFighter characterFighter:
                        client.SendPacket(new GameFightShowFighterMessage(characterFighter.GetGameFightCharacterInformations()));
                        break;
                    case MonsterFighter monsterFighter:
                        client.SendPacket(new GameFightShowFighterMessage(monsterFighter.GetGameFightMonsterInformations()));
                        break;
                }
            }
        }

        public List<FightTeamInformations> GetFightTeamInformations()
        {
            List<FightTeamInformations> fightTeamInformations = new List<FightTeamInformations>();

            //challengers:
            List<FightTeamMemberInformations> challengers = new List<FightTeamMemberInformations>();
            foreach(var fighter in this.Challengers)
            {
                if(fighter is CharacterFighter characterFighter)
                {
                    challengers.Add(new FightTeamMemberCharacterInformations(characterFighter.Id, characterFighter.Character.Name, (uint)characterFighter.Character.Level));
                }
            }

            fightTeamInformations.Add(new FightTeamInformations((uint)TeamEnum.TEAM_CHALLENGER, this.Challengers[0].Id, 255, (uint)TeamEnum.TEAM_CHALLENGER, 0, challengers));

            //defenders:
            List<FightTeamMemberInformations> defenders = new List<FightTeamMemberInformations>();
            foreach (var fighter in this.Defenders)
            {
                switch (fighter)
                {
                    case CharacterFighter characterFighter:
                        defenders.Add(new FightTeamMemberCharacterInformations(characterFighter.Id, characterFighter.Character.Name, (uint)characterFighter.Character.Level));
                        break;
                    case MonsterFighter monsterFighter:
                        defenders.Add(new FightTeamMemberMonsterInformations(monsterFighter.Id, monsterFighter.Monster.Id, monsterFighter.Monster.Grades[0].Grade));
                        break;
                }
            }
            fightTeamInformations.Add(new FightTeamInformations((uint)TeamEnum.TEAM_DEFENDER, this.Defenders[0].Id, 255, (uint)TeamEnum.TEAM_DEFENDER, 0, defenders));

            return fightTeamInformations;
        }

        public List<FightTeamMemberInformations> GetFightTeamMemberInformations()
        {
            List<FightTeamMemberInformations> challengers = new List<FightTeamMemberInformations>();
            foreach (var fighter in this.Challengers)
            {
                if (fighter is CharacterFighter characterFighter)
                {
                    challengers.Add(new FightTeamMemberCharacterInformations(characterFighter.Id, characterFighter.Character.Name, (uint)characterFighter.Character.Level));
                }
            }

            List<FightTeamMemberInformations> defenders = new List<FightTeamMemberInformations>();
            foreach (var fighter in this.Defenders)
            {

                switch(fighter)
                {
                    case CharacterFighter characterFighter:
                        defenders.Add(new FightTeamMemberCharacterInformations(characterFighter.Id, characterFighter.Character.Name, (uint)characterFighter.Character.Level));
                        break;
                    case MonsterFighter monsterFighter:
                        defenders.Add(new FightTeamMemberMonsterInformations(monsterFighter.Id, monsterFighter.Monster.Id, monsterFighter.Monster.Grades[0].Grade));
                        break;
                }
            }

            return challengers.Concat(defenders).ToList();
        }

        public FightCommonInformations GetFightCommonInformations()
        {
            return new FightCommonInformations((uint)this.Id, (uint)this.FightType, this.GetFightTeamInformations(),
                        new List<uint>() { 452, 397 }, new List<FightOptionsInformations>(){
                            new FightOptionsInformations(false, false, false,false),
                            new FightOptionsInformations(false, false, false, false)
                        });
        }

        public bool CanChangeStartingPositions(WorldClient client, int requestedCellId)
        {
            if (this.FightState != FightStateEnum.FIGHT_CHOICE_PLACEMENT)
                return false;

            CharacterFighter fighter = (CharacterFighter)this.Fighters.Find(x => x is CharacterFighter && x.Id == client.ActiveCharacter.Id);

            if (fighter == null)
                return false;


            bool isStartingPos = fighter.Team == TeamEnum.TEAM_CHALLENGER ?
                (this.FightStartingPositions.positionsForChallengers.Find(x => x == requestedCellId) != 0 ? true : false) :
                (this.FightStartingPositions.positionsForDefenders.Find(x => x == requestedCellId) != 0 ? true : false);

            if (!isStartingPos)
                return false;

            bool isFreeCell = fighter.Team == TeamEnum.TEAM_CHALLENGER ?
                (this.Challengers.Find(x => x.CellId == requestedCellId) != null ? false : true) :
                (this.Defenders.Find(x => x.CellId == requestedCellId) != null ? false : true);

            if (!isFreeCell)
                return false;

            fighter.CellId = requestedCellId;
            this.SendFighterDispositionInformations(fighter);

            return true;
        }

        private void SendToAllFighters(List<NetworkMessage> messages)
        {
            foreach (var fighter in this.Fighters.Where(x => x is CharacterFighter))
            {
                var client = WorldManager.Instance.GetClientFromCharacter(((CharacterFighter)fighter).Character);
                if (client != null)
                {
                    foreach (var msg in messages)
                    {
                        client.SendPacket(msg);
                    }
                }
            }
        }

        public void TurnEnd()
        {
            TurnTimer.Stop();

            if (this.FightState != FightStateEnum.FIGHT_STARTED)
                return;

            //queue message
            List<NetworkMessage> messages = new List<NetworkMessage>();
            messages.Add(new GameFightTurnEndMessage((double)this.ActualFighter.Id)); //fin du tour
            messages.Add(new GameFightTurnReadyRequestMessage((double)this.ActualFighter.Id));


            //reset AP/PM
            if (this.ActualFighter is CharacterFighter)
                ((CharacterFighter)this.ActualFighter).ResetFighter();

            var aliveFighters = this.Fighters.OrderBy(x => x.TimelineOrder).ToList().FindAll(x => x.Life > 0);
            var nextFighter = this.Fighters.Concat(this.Defenders).OrderBy(x => x.TimelineOrder).ToList().Find(x => x.TimelineOrder > this.ActualFighter.TimelineOrder && x.Life > 0);

            if (aliveFighters.Count == 0) //impossible normalement car endfight plutot mais on ne sais jamais
                return;

            if (nextFighter == null)
            {
                this.ActualFighter = aliveFighters.First();
                this.Round += 1;
                messages.Add(new GameFightNewRoundMessage((uint)this.Round));
            }
            else
            {
                this.ActualFighter = nextFighter;
            }


            Console.WriteLine("FIN DU TOUR DE JEU");
            Console.WriteLine("NOUVEAU TOUR POUR {0} authorId.", this.ActualFighter.Id);

            int nextTurnSecondes = 320;
            if (this.ActualFighter is MonsterFighter)
                nextTurnSecondes = 150;

            messages.Add(new GameFightTurnStartMessage(this.ActualFighter.Id, (uint)nextTurnSecondes)); //nouveau tour

            this.SendToAllFighters(messages);

            this.StartTurnTimer(nextTurnSecondes);

            if(this.ActualFighter is MonsterFighter)
            {
                //IA RUSHER EXPERIMENTAL POUR MOMENT
                var nearestFighter = BrainManager.Instance.AIGetNearestFighter(this, (MonsterFighter)this.ActualFighter);
                BrainManager.Instance.AIMoveToTarget(this, nearestFighter);
                BrainManager.Instance.AILaunchSpellToTarget(this, nearestFighter);

                this.TurnEnd();
            }
            else
            {
                this.SynchronizeSequence((CharacterFighter)this.ActualFighter);
            }
        }
        
        public void SendSequence(SequenceTypeEnum sequenceType, List<NetworkMessage> messages, uint actionId = 3)
        {
            if (this.FightState == FightStateEnum.FIGHT_ENDED)
                return;

            messages.Insert(0, new SequenceStartMessage((int)sequenceType, this.ActualFighter.Id));
            messages.Add(new SequenceEndMessage(actionId, this.ActualFighter.Id, (int)sequenceType));

            this.SendToAllFighters(messages);
        }

        private void SynchronizeSequence(CharacterFighter characterFighter)
        {
            List<NetworkMessage> messages = new List<NetworkMessage>();

            messages.Add(characterFighter.GetFighterStatsListMessage());
            messages.Add(this.GetGameFightSynchronizeMessage());

            this.SendSequence(SequenceTypeEnum.SEQUENCE_TURN_START, messages, 70);

        }

        private GameFightSynchronizeMessage GetGameFightSynchronizeMessage()
        {
            List<GameFightFighterInformations> fightFighterInformations = new List<GameFightFighterInformations>();

            foreach (var fighter in this.Fighters.FindAll(x => x.Life > 0))
            {
                if (fighter is CharacterFighter)
                    fightFighterInformations.Add(((CharacterFighter)fighter).GetGameFightCharacterInformations());
                else if (fighter is MonsterFighter)
                    fightFighterInformations.Add(((MonsterFighter)fighter).GetGameFightMonsterInformations());
            }
            return new GameFightSynchronizeMessage(fightFighterInformations);
        }

        public void MovementRequestSequence(int requestedCellId)
        {
            var usedCells = this.Fighters.Where(f => f.Life > 0).Select(x => (int)x.CellId).ToArray();

            var path = new Pathfinder(usedCells);
            path.SetMap(this.Map.MapData, false);

            var cells = path.GetPath((short)this.ActualFighter.CellId, (short)requestedCellId).Select(x => (uint)x.Id).ToList();

            if (cells.Count <= 1)
                return;

            var cellDistance = (cells.Count - 1); // taille du déplacement - la cell de départ

            if (cellDistance > this.ActualFighter.PM)
                return;

            this.ActualFighter.CellId = MapManager.Instance.GetCellIdFromKeyMovement((int)cells[cells.Count - 1]);
            this.ActualFighter.PM -= cellDistance; //- distance

            
            List<NetworkMessage> queueMessages = new List<NetworkMessage>();
            queueMessages.Add(new GameMapMovementMessage(cells, 3, this.ActualFighter.Id));
            queueMessages.Add(new GameActionFightPointsVariationMessage(129, this.ActualFighter.Id, this.ActualFighter.Id, -(cellDistance)));


            SendSequence(SequenceTypeEnum.SEQUENCE_MOVE, queueMessages);

            //this.SendToAllFighters(queueMessages);
        }

        public void CastSpellRequestSequence(int cellId, int spellId)
        {
            if(this.ActualFighter is CharacterFighter characterFighter)
            {
                var spellItem = characterFighter.Character.GetAvaibleSpells().Find(x => x.spellId == spellId);
                if (spellItem == null)
                    return;


                var spellTemplate = SpellRepository.Instance.GetSpellById(spellId);
                var spellLevel = SpellLevelRepository.Instance.GetSpellLevelById((int)spellTemplate.SpellLevels[spellItem.spellLevel - 1]);

                //si pas assez de Point actions
                if (spellLevel.ApCost > this.ActualFighter.AP)
                    return;

                //on enleve les PA
                this.ActualFighter.AP -= (int)spellLevel.ApCost;
                bool castLaunched = false;
                List<NetworkMessage> queueMessages = new List<NetworkMessage>();

                Dictionary<int, int> effectAlreadyApplyqued = new Dictionary<int, int>();

                queueMessages.Add(new DebugClearHighlightCellsMessage());

                foreach (var effect in spellLevel.Effects)
                {
                    var rawZone = new RawZone(effect.RawZone);
                    uint effectZoneStopAtTarget = effect.ZoneStopAtTarget != null ? (uint)effect.ZoneStopAtTarget : 0;
                    var shapeZone = SpellZoneManager.Instance.getZone(this.Map.MapData, rawZone.m_zoneShape, rawZone.m_zoneSize, rawZone.m_zoneMinSize, this.ActualFighter.CellId, cellId, false, effectZoneStopAtTarget, false);

                    var targetMask = SpellZoneManager.Instance.GetFightersHitFromTargetMask(this, shapeZone.getCells((uint)cellId), this.ActualFighter, (uint)cellId, effect);

                    queueMessages.Add(new DebugHighlightCellsMessage(Color.Aquamarine.ToArgb(), shapeZone.getCells((uint)cellId)));

                    //var targets = this.Fighters.FindAll(x => shapeZone.getCells((uint)cellId).Contains((uint)x.CellId));
                    var targets = targetMask;

                    foreach (var target in targets)
                    {
                        if (!castLaunched)
                        {
                            queueMessages.Add(new GameActionFightSpellCastMessage(300, this.ActualFighter.Id, target.Id, cellId, 0, false, true, (uint)spellId, spellItem.spellLevel, new List<int>()));
                            castLaunched = true;
                        }
                            
                        Console.WriteLine("LIFE BEFORE EFFECTMANAGER {0}pdv", target.Life);

                        //manager for effects from spell
                        SpellEffectManager.Instance.BuildEffect(this.ActualFighter, target, effect, queueMessages);

                        Console.WriteLine("LIFE AFTER EFFECTMANAGER {0}pdv", target.Life);
                    }
                }
                queueMessages.Add(new GameActionFightPointsVariationMessage(102, this.ActualFighter.Id, this.ActualFighter.Id, -((int)spellLevel.ApCost)));

                this.SendSequence(SequenceTypeEnum.SEQUENCE_SPELL, queueMessages);
            }
        }

        public void StartPlacementPhaseTimer()
        {
            if (this.FightState != FightStateEnum.FIGHT_CHOICE_PLACEMENT)
                return;

            PlacementPhaseTimer = new Timer(5000);
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
                    PlacementPhaseTimer.Stop();

                    this.ElapsdedTime = new Stopwatch();
                    this.ElapsdedTime.Start();

                    //actualise l'ordre dans la timeline
                    var orderedFighters = this.Fighters.OrderByDescending(x => x.Initiative).ToList();
                    for(int i = 0; i < orderedFighters.Count; i++)
                    {
                        orderedFighters[i].TimelineOrder = (i + 1);
                    }

                    //remove le fight affiché sur la map car plus possible de le rejoindre
                    this.Map.RemoveFightInformationsOnMap(this.Id);


                    List<NetworkMessage> messages = new List<NetworkMessage>();
                    messages.Add(new GameFightStartMessage(new List<Idol>()));
                    messages.Add(new GameFightTurnListMessage(orderedFighters.Select(x => (double)x.Id).ToList(), new List<double> { }));
                    messages.Add(new BasicNoOperationMessage());


                    this.ActualFighter = orderedFighters[0];
                    this.Round = 1;

                    if(this.FightState == FightStateEnum.FIGHT_CHOICE_PLACEMENT)
                        this.FightState = FightStateEnum.FIGHT_STARTED;

                    messages.Add(this.GetGameFightSynchronizeMessage());

                    messages.Add(new GameFightNewRoundMessage((uint)this.Round));
                    messages.Add(new GameFightTurnStartMessage(this.ActualFighter.Id, 50));

                    this.SendToAllFighters(messages);

                    this.StartTurnTimer(50);
                    break;
                case FightStateEnum.FIGHT_STARTED:
                    //todo faire une fonction qui turnEnd
                    this.TurnEnd();
                    break;
                case FightStateEnum.FIGHT_ENDED:
                    if (this.TurnTimer.Enabled)
                        this.TurnTimer.Stop();
                    break;
            }
        }

        public void EndFight()
        {

            if (this.FightState == FightStateEnum.FIGHT_ENDED)
                return;

            //fin du timer
            this.CloseTurnTimer();
            this.ElapsdedTime.Stop();
            this.FightState = FightStateEnum.FIGHT_ENDED;

            this.TeamWinner = this.Challengers.FindAll(x => x.Life > 0).Count != 0 ? TeamEnum.TEAM_CHALLENGER : TeamEnum.TEAM_DEFENDER;

            //on enleve le fight de la map
            this.Map.RemoveFight(this);

            List<NetworkMessage> messages = new List<NetworkMessage>();

            List<FightResultListEntry> fightResultLists = new List<FightResultListEntry>();

            foreach (var fighter in this.Fighters)
            {
                //winner = 2 - looser = 0
                int outcome = fighter.Team == this.TeamWinner ? 2 : 0;
                if(fighter is CharacterFighter characterFighter)
                {
                    var client = this.Map.GetClientFromCharacter(characterFighter.Character);

                    double expEarned = FightManager.Instance.GetExperienceEarned(characterFighter.Character, this);
                    var loots = FightManager.Instance.GetDropEarned(characterFighter.Character, this);
                    int kamas = FightManager.Instance.getKamasEarned(characterFighter.Character, this);


                    FightManager.Instance.SaveCharacterEndFightProgress(this.Map, characterFighter.Character, loots, expEarned, kamas);
                    

                    fightResultLists.Add(new FightResultPlayerListEntry((uint)outcome, 0, new FightLoot(loots, kamas), fighter.Id, fighter.Life > 0, (uint)characterFighter.Character.Level, new List<FightResultAdditionalData>()
                    {
                        new FightResultExperienceData(characterFighter.Character.Experience + expEarned, true, LevelManager.Instance.GetActualLevelExperience<Character>(characterFighter.Character).Experience, true, LevelManager.Instance.GetNextLevelByExperience<Character>(characterFighter.Character).Experience, true, expEarned, true, 0.0, true, 0.0, true, false, 0)
                    }));
                }
                else
                {
                    fightResultLists.Add(new FightResultFighterListEntry((uint)outcome, 0, new FightLoot(), fighter.Id, fighter.Life > 0));
                }
            }

            messages.Add(new GameFightEndMessage((uint)this.ElapsdedTime.ElapsedMilliseconds, 0, -1, fightResultLists, new List<NamedPartyTeamWithOutcome>()));
            //envoyer comme si on charge une map

            this.SendToAllFighters(messages);
            FightManager.Instance.Fights.Remove(this);

            Console.WriteLine("Fin du fight");
        }


        private void CloseTurnTimer()
        {
            if (!this.TurnTimer.Enabled)
                return;


            this.TurnTimer.Close();
            this.TurnTimer.Dispose();
        }

    }
}
