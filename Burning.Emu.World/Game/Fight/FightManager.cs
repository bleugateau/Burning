using Burning.Common.Managers.Singleton;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Game.Fight.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Fight
{
    public class FightManager : SingletonManager<FightManager>
    {
        public List<Fight> Fights { get; set; }

        private double[] palierGroup = new double[] { 1, 1.1, 1.5, 2.3, 3.1, 3.6, 4.2, 4.7 };

        public void Initialize()
        {
            this.Fights = new List<Fight>();
        }

        private int truncate(double param1)
        {
            double _loc_2 = Math.Pow(10, 0);
            int _loc_3 = (int)(param1 * _loc_2);
            return (int)((_loc_3) / _loc_2);
        }


        public int getExperienceEarned(Character character, Fight fight)
        {
            var monsters = fight.Defenders.Where(x => x.Life <= 0).Select(x => (MonsterFighter)x).ToList();
            var characters = fight.Challengers.Select(x => (CharacterFighter)x).ToList();

            if (!monsters.Any() || !characters.Any())
                return 0;

            int sumPlayersLevel = characters.Sum(entry => entry.Character.Level);
            byte maxPlayerLevel = characters.Max(entry => (byte)entry.Character.Level);
            int sumMonstersLevel = monsters.Sum(entry => (int)entry.Monster.Grades[0].Level);
            byte maxMonsterLevel = monsters.Max(entry => (byte)entry.Monster.Grades[0].Level);
            int sumMonsterXp = monsters.Sum(entry => entry.Monster.Grades[0].GradeXp);

            double levelCoeff = 1;
            if (sumPlayersLevel - 5 > sumMonstersLevel)
                levelCoeff = (double)sumMonstersLevel / sumPlayersLevel;
            else if (sumPlayersLevel + 10 < sumMonstersLevel)
                levelCoeff = (sumPlayersLevel + 10) / (double)sumMonstersLevel;

            double xpRatio = Math.Min(character.Level, Math.Truncate(2.5d * maxMonsterLevel)) / sumPlayersLevel * 100d;

            int regularGroupRatio = characters.Where(entry => entry.Character.Level >= maxPlayerLevel / 3).Sum(entry => 1);

            if (regularGroupRatio <= 0)
                regularGroupRatio = 1;

            double baseXp = Math.Truncate(xpRatio / 100 * Math.Truncate(sumMonsterXp * palierGroup[regularGroupRatio - 1] * levelCoeff));
            //double multiplicator = fighter.Fight.AgeBonus <= 0 ? 1 : 1 + fighter.Fight.AgeBonus / 100d;
            var xp = (int)Math.Truncate(Math.Truncate(baseXp * (100 + character.Characteristics.wisdom.Total) / 100d) * 1);

            return xp;
        }

        public int getKamasEarned(Character character, Fight fight)
        {
            var monsters = fight.Defenders.Where(x => x.Life <= 0).Select(x => (MonsterFighter)x).ToList();
            return Math.Min(character.Level, monsters.Sum(x => (int)x.Monster.Grades[0].Level));
        }
    }
}
