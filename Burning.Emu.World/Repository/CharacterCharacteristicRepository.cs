using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.DofusProtocol.Enums;
using Burning.Emu.World.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Repository
{
    public class CharacterCharacteristicRepository : SingletonManager<CharacterCharacteristicRepository>, IRepository<CharacterCharacteristic>
    {
        public IMongoCollection<CharacterCharacteristic> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<CharacterCharacteristic>(dataName);
        }

        public void Insert(CharacterCharacteristic entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(CharacterCharacteristic entity)
        {
            this.Collection.ReplaceOne(Builders<CharacterCharacteristic>.Filter.Eq("_id", entity.Id), entity);
        }

        public CharacterCharacteristic GetCharacteristicsByCharacter(Character character)
        {
            return this.Collection.Find(Builders<CharacterCharacteristic>.Filter.Eq("CharacterId", character.Id)).Limit(1).FirstOrDefault();
        }

        public int CalculStats(List<List<uint>> statsPointForCharacteristic, int characteristicBase, uint boostPoint)
        {
            int pointsUsed = 0;
            var statJalon = statsPointForCharacteristic[0];
            for (int i = 0; i < boostPoint; i++)
            {

                foreach (var s in statsPointForCharacteristic)
                {
                    if (s[0] <= characteristicBase)
                    {
                        statJalon = s;
                    }
                }

                pointsUsed++;

                if (statJalon[1] == pointsUsed)
                {
                    pointsUsed = 0;
                    characteristicBase += 1;
                }
            }

            return characteristicBase;
        }

        public bool StatsUpgradeRequestAction(Character character, uint boostPoint, uint statId)
        {
            //si pas le nombre suffisant
            if (character.Characteristics.CapitalPoint < (int)boostPoint)
            {
                return false;
            }

            var breed = BreedRepository.Instance.List.Find(x => x.Id == character.Breed);
            var characteristic = character.Characteristics;

            switch ((BoostableCharacteristicEnum)statId)
            {
                case BoostableCharacteristicEnum.BOOSTABLE_CHARAC_AGILITY:
                    characteristic.agility.@base += this.CalculStats(breed.StatsPointsForAgility, character.Characteristics.agility.@base, boostPoint);
                    break;
                case BoostableCharacteristicEnum.BOOSTABLE_CHARAC_CHANCE:
                    characteristic.chance.@base += this.CalculStats(breed.StatsPointsForChance, character.Characteristics.chance.@base, boostPoint);
                    break;
                case BoostableCharacteristicEnum.BOOSTABLE_CHARAC_INTELLIGENCE:
                    characteristic.intelligence.@base += this.CalculStats(breed.StatsPointsForIntelligence, character.Characteristics.intelligence.@base, boostPoint);
                    break;
                case BoostableCharacteristicEnum.BOOSTABLE_CHARAC_STRENGTH:
                    characteristic.strength.@base += this.CalculStats(breed.StatsPointsForStrength, character.Characteristics.strength.@base, boostPoint);
                    break;
                case BoostableCharacteristicEnum.BOOSTABLE_CHARAC_VITALITY:
                    characteristic.vitality.@base += this.CalculStats(breed.StatsPointsForVitality, character.Characteristics.vitality.@base, boostPoint);
                    break;
                case BoostableCharacteristicEnum.BOOSTABLE_CHARAC_WISDOM:
                    characteristic.wisdom.@base += this.CalculStats(breed.StatsPointsForWisdom, character.Characteristics.wisdom.@base, boostPoint);
                    break;
                default:
                    return false;
            }

            characteristic.initiative.@base = (characteristic.agility.@base + characteristic.chance.@base + characteristic.intelligence.@base + characteristic.strength.@base + characteristic.vitality.@base + characteristic.wisdom.@base);
            characteristic.CapitalPoint -= (int)boostPoint;
            characteristic.UsedCapitalPoint += (int)boostPoint;

            this.Update(characteristic);

            return true;
        }
    }
}
