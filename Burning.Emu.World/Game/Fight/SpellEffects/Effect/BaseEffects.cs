using Burning.Common.Managers.Damage;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Messages;
using Burning.Emu.World.Game.Fight.Fighters;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Effects.Effect
{
    public class BaseEffects : AbstractEffect
    {
        [EffectEnumAttribute(DofusProtocol.Enums.EffectsEnum.Effect_DamageAir)]
        public void Effect_DamageAir(Fighter caster, Fighter target, EffectInstanceDice effect, List<NetworkMessage> queueMessages)
        {
            SendBaseEffect(caster, target, effect, queueMessages);
        }

        [EffectEnumAttribute(DofusProtocol.Enums.EffectsEnum.Effect_DamageWater)]
        public void Effect_DamageWater(Fighter caster, Fighter target, EffectInstanceDice effect, List<NetworkMessage> queueMessages)
        {
            SendBaseEffect(caster, target, effect, queueMessages);
        }

        [EffectEnumAttribute(DofusProtocol.Enums.EffectsEnum.Effect_DamageEarth)]
        public void Effect_DamageEarth(Fighter caster, Fighter target, EffectInstanceDice effect, List<NetworkMessage> queueMessages)
        {
            SendBaseEffect(caster, target, effect, queueMessages);
        }

        [EffectEnumAttribute(DofusProtocol.Enums.EffectsEnum.Effect_DamageFire)]
        public void Effect_DamageFire(Fighter caster, Fighter target, EffectInstanceDice effect, List<NetworkMessage> queueMessages)
        {
            SendBaseEffect(caster, target, effect, queueMessages);
        }

        [EffectEnumAttribute(DofusProtocol.Enums.EffectsEnum.Effect_DamageNeutral)]
        public void Effect_DamageNeutral(Fighter caster, Fighter target, EffectInstanceDice effect, List<NetworkMessage> queueMessages)
        {
            SendBaseEffect(caster, target, effect, queueMessages);
        }

        private void SendBaseEffect(Fighter caster, Fighter target, EffectInstanceDice effect, List<NetworkMessage> queueMessages)
        {

            int damage = 0;
            switch((EffectsEnum)effect.EffectId)
            {
                case EffectsEnum.Effect_DamageNeutral:
                    damage = DamageCalculatorManager.Instance.GetDamage(effect, caster.AllDamageBonus, caster.Strength, caster.StrengthDamageBonus, target.NeutralResistance, target.NeutralPercentResistance);
                    break;
                case EffectsEnum.Effect_DamageEarth:
                    damage = DamageCalculatorManager.Instance.GetDamage(effect, caster.AllDamageBonus, caster.Strength, caster.StrengthDamageBonus, target.StrengthResistance, target.StrengthPercentResistance);
                    break;
                case EffectsEnum.Effect_DamageWater:
                    damage = DamageCalculatorManager.Instance.GetDamage(effect, caster.AllDamageBonus, caster.Water, caster.WaterDamageBonus, target.WaterResistance, target.WaterPercentResistance);
                    break;
                case EffectsEnum.Effect_DamageFire:
                    damage = DamageCalculatorManager.Instance.GetDamage(effect, caster.AllDamageBonus, caster.Intelligence, caster.IntelligenceDamageBonus, target.IntelligenceResistance, target.IntelligencePercentResistance);
                    break;
                case EffectsEnum.Effect_DamageAir:
                    damage = DamageCalculatorManager.Instance.GetDamage(effect, caster.AllDamageBonus, caster.Agility, caster.AgilityDamageBonus, target.AgilityResistance, target.AgilityPercentResistance);
                    break;
            }
            
            if (damage > target.Life)
                damage = target.Life;

            if (target.Life > 0)
            {
                target.Life -= damage;

                queueMessages.Add(new GameActionFightLifePointsLostMessage(283, caster.Id, target.Id, (uint)damage, (uint)(damage / 10), effect.EffectElement));


                if (target.Life <= 0)
                    queueMessages.Add(new GameActionFightDeathMessage(103, caster.Id, target.Id));

                //trigger event here
                target.OnLifeLost();
            }
            
        }

    }
}
