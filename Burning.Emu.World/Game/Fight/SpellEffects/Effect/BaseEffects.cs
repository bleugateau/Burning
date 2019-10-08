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
            target.Life -= (int)effect.DiceNum;

            queueMessages.Add(new GameActionFightLifePointsLostMessage(300, caster.Id, target.Id, effect.DiceNum, effect.DiceNum, effect.EffectElement)); //si enemi perd pdv
        }

    }
}
