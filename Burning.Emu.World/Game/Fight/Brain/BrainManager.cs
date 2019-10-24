using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Messages;
using Burning.Emu.World.Game.Fight.Effects;
using Burning.Emu.World.Game.Fight.Fighters;
using Burning.Emu.World.Game.Fight.Spell;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Game.PathFinder;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Brain
{
    public class BrainManager : SingletonManager<BrainManager>
    {
        public Fighter AIGetNearestFighter(Fight fight, MonsterFighter fighter)
        {
            var map = fight.Map;

            var cellChallengers = fight.Challengers.Where(c => c.Life > 0).Select(x => map.MapData.Cells.ToList().FirstOrDefault(c => c.Id == x.CellId)).ToList();
            var cellData = map.MapData.Cells.ToList().FirstOrDefault(x => x.Id == fighter.CellId);

            if (map != null)
            {
                var nearestChallengerCell = cellChallengers.OrderBy(x => MapManager.Instance.DistanceBetweenCell(new Point(cellData.X, cellData.Y), new Point(x.X, x.Y))).FirstOrDefault();

                if (nearestChallengerCell != null)
                {
                    Console.WriteLine("{0} is nearest cellId.", nearestChallengerCell.Id);
                    return fight.Challengers.Find(x => x.CellId == nearestChallengerCell.Id);
                }

            }

            return null;
        }

        public void AIMoveToTarget(Fight fight, Fighter target)
        {

            if (target == null)
                return;

            var usedCells = fight.Defenders.Concat(fight.Challengers).Where(f => f.Life > 0).Select(x => (int)x.CellId).ToArray();
            var map = fight.Map;

            var path = new Pathfinder(usedCells);
            path.SetMap(map.MapData, false);

            var movement = path.GetPath((short)fight.ActualFighter.CellId, (short)target.CellId);

            if (movement.Count > 1)
            {
                List<uint> cells = new List<uint>();
                int lastOrientation = 0;
                for (int i = 0; i < movement.Count; i++)
                {
                    if ((cells.Count - 1) == fight.ActualFighter.PM)
                        break;

                    if (movement[i].Id != target.CellId)
                    {
                        cells.Add((uint)movement[i].Id);
                        lastOrientation = movement[i].Orientation;
                    }
                }

                List<NetworkMessage> queueMessages = new List<NetworkMessage>();
                //queueMessages.Add(new SequenceStartMessage((int)SequenceTypeEnum.SEQUENCE_MOVE, this.ActualFighter.Id));
                queueMessages.Add(new GameMapMovementMessage(cells, lastOrientation, fight.ActualFighter.Id));
                queueMessages.Add(new GameActionFightPointsVariationMessage(129, fight.ActualFighter.Id, fight.ActualFighter.Id, -(cells.Count - 1)));
                //queueMessages.Add(new SequenceEndMessage(3, this.ActualFighter.Id, (int)SequenceTypeEnum.SEQUENCE_MOVE));

                if (cells.Count != 0)
                    fight.ActualFighter.CellId = (int)cells[cells.Count - 1];


                fight.SendSequence(SequenceTypeEnum.SEQUENCE_MOVE, queueMessages);
            }
        }

        public void AILaunchSpellToTarget(Fight fight, Fighter target)
        {
            var fighter = ((MonsterFighter)fight.ActualFighter);

            //si aucun spell
            if (fighter.Monster.Spells.Count == 0)
                return;


            Random random = new Random();

            int spellId = random.Next(0, fighter.Monster.Spells.Count);

            var spellTemplate = SpellRepository.Instance.GetSpellById((int)fighter.Monster.Spells[(int)spellId]);
            var spellLevel = SpellLevelRepository.Instance.GetSpellLevelById((int)spellTemplate.SpellLevels[0]);


            var spellInabilityReason = SpellRangeManager.CanLaunchSpell(fight.Defenders.Concat(fight.Challengers).Select(x => (int)x.CellId).ToList(), spellTemplate.Id, fighter.CellId, target.CellId);

            if (spellInabilityReason == SpellInabilityReason.None && spellTemplate.Id != 0 && spellLevel.ApCost != 0)
            {
                List<NetworkMessage> queueMessages = new List<NetworkMessage>();
                //queueMessages.Add(new SequenceStartMessage((int)SequenceTypeEnum.SEQUENCE_SPELL, fight.ActualFighter.Id));
                queueMessages.Add(new GameActionFightSpellCastMessage(300, fight.ActualFighter.Id, target.Id, target.CellId, 0, false, true, (uint)spellId, 1, new List<int>()));

                queueMessages.Add(new GameActionFightPointsVariationMessage(102, fight.ActualFighter.Id, fight.ActualFighter.Id, -((int)spellLevel.ApCost)));

                //on enleve les PA
                //this.ActualFighter.AP -= (int)selectedSpellLevel.ApCost;

                Console.WriteLine("LIFE BEFORE EFFECTMANAGER {0}pdv", target.Life);


                foreach (var effect in spellLevel.Effects)
                {
                    //manager for effects from spell
                    SpellEffectManager.Instance.BuildEffect(fight.ActualFighter, target, effect, queueMessages);
                }

                


                Console.WriteLine("LIFE AFTER EFFECTMANAGER {0}pdv", target.Life);

                //queueMessages.Add(new GameActionFightLifePointsLostMessage(300, this.ActualFighter.Id, target.Id, 1, 1, 1)); //si enemi perd pdv
                //queueMessages.Add(new SequenceEndMessage(3, this.ActualFighter.Id, (int)SequenceTypeEnum.SEQUENCE_SPELL));

                fight.SendSequence(SequenceTypeEnum.SEQUENCE_SPELL, queueMessages);
            }

        }
    }
}
