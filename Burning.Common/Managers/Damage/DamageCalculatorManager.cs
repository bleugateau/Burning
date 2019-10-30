using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Managers.Damage
{
    /*
     * https://www.dofus.com/fr/mmorpg/tutoriels/420181-dommages-resistances
     */
    public class DamageCalculatorManager : SingletonManager<DamageCalculatorManager>
    {

        private readonly Random _random = new Random();


        public int GetDamage(EffectInstanceDice effect, int puissance, int caracteristic, int bonusFixDamage, int fixResistance, int pourcentResistance)
        {
            int totalDamage = this.GetDamageTotalFromEffect(effect, puissance, caracteristic, bonusFixDamage);
            int sufferedDamage = GetDamageSuffered(totalDamage, fixResistance, pourcentResistance);

            if (sufferedDamage <= 0)
                return 0;

            return sufferedDamage;
        }

        public int GetDamageTotalFromEffect(EffectInstanceDice effect, int puissance, int caracteristic, int bonusFixDamage)
        {
            //Dégâts totaux = dégâts de base + dégâts de base * ((Puissance + caractéristique) / 100) + bonus aux dégâts fixe.
            int minEffectDamage = (int)effect.DiceNum;
            int maxEffectDamage = (int)effect.DiceSide;

            if (maxEffectDamage == 0 || maxEffectDamage < minEffectDamage)
                maxEffectDamage = minEffectDamage;

            int minBaseDamage = (int)Math.Floor(minEffectDamage + minEffectDamage * ((puissance + caracteristic) * 0.01) + bonusFixDamage);
            int maxBaseDamage = (int)Math.Floor(maxEffectDamage + maxEffectDamage * ((puissance + caracteristic) * 0.01) + bonusFixDamage);

            return this._random.Next(minBaseDamage, maxBaseDamage + 1);
        }

        public int GetDamageSuffered(int totalDamage, int fixResistance, int pourcentResistance)
        {
            //dégâts totaux - résistance fixe - (dégâts totaux / 100/pourcentage de résistance)
            if (pourcentResistance == 0)
                pourcentResistance = 1;

            totalDamage -= fixResistance;

            int divident = ((totalDamage * pourcentResistance) / 100) * -1;

            if (pourcentResistance < 0)
                divident = ((totalDamage * (pourcentResistance * -1)) / 100);

            return totalDamage  + (divident);
        }
    }
}
