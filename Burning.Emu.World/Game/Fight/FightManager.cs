using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Network.Messages;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Game.Fight.Fighters;
using Burning.Emu.World.Repository;
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

        private Random random = new Random();

        public void Initialize()
        {
            this.Fights = new List<Fight>();
        }

        public void SaveCharacterEndFightProgress(Map.Map map, Character character, List<uint> loots, int experienceEarned, int kamasEarned)
        {
            var client = map.GetClientFromCharacter(character);
            var inventory = character.Inventory;

            character.Experience += experienceEarned;

            if (experienceEarned > 1000) //gerer l'exp TODO
            {
                character.Level += 1;

                if (client != null)
                    client.SendPacket(new CharacterLevelUpMessage((uint)character.Level));
            }

            character.Kamas += kamasEarned;

            foreach (var loot in loots)
            {
                var item = InventoryRepository.Instance.GenerateItemFromId((int)loot);

                if (item == null)
                    continue;

                inventory.ObjectItems.Add(InventoryRepository.Instance.GenerateItemFromId((int)loot));

                if (client == null)
                    continue;
                client.SendPacket(new ObjectAddedMessage(item, 0));
                client.SendPacket(new InventoryWeightMessage(0, 0, 1000));
            }

            CharacterRepository.Instance.Update(character);
            InventoryRepository.Instance.Update(inventory);

            if (client != null)
            {
                client.ActiveCharacter = character;
                //exit de la map le joueur pour le faire actualiser la carte TODO
            }

        }

        public List<uint> GetDropEarned(Character character, Fight fight)
        {
            var monsters = fight.Defenders.Where(x => x.Life <= 0).Select(x => (MonsterFighter)x).ToList();
            var client = fight.Map.GetClientFromCharacter(character);

            List<uint> drops = new List<uint>();

            foreach(var monster in monsters)
            {
                foreach(var loot in monster.Monster.Drops.Where(x => x.Criteria == "null"))
                {
                    //calcul sur dofus pour les noobs a prendre
                    if(this.IsDropEarned((int)loot.PercentDropForGrade1 * (character.Characteristics.prospecting.Total / 100)))
                    {
                        drops.Add((uint)loot.ObjectId);
                        drops.Add(1);
                        Console.WriteLine("Dropped {1} with {0}%", loot.PercentDropForGrade1, loot.ObjectId);
                    }
                }
            }

            return drops;
        }

        private bool IsDropEarned(int dropPourcentage)
        {
            List<int> diceNumbers = new List<int>();
            Random random = new Random();

            if (dropPourcentage >= 100)
                return true;

            for (int i = 0; i < dropPourcentage; i++)
            {
                List<int> range = Enumerable.Range(1, 100).Where(x => !diceNumbers.Contains(x)).ToList();

                int index = random.Next(0, range.Count);
                int dice = range.ElementAt(index);

                diceNumbers.Add(dice);
            }

            if (diceNumbers.Contains(this.random.Next(1, 100 + 1)))
                return true;

            return false;
        }

        public int GetExperienceEarned(Character character, Fight fight)
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
