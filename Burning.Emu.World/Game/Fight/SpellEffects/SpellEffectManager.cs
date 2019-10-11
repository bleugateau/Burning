using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Enums;
using Burning.Emu.World.Game.Fight.Fighters;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Effects
{
    public class SpellEffectManager : SingletonManager<SpellEffectManager>
    {
        private Dictionary<EffectsEnum, EffectData> EffectsList = new Dictionary<EffectsEnum, EffectData>();

        public void Initialize()
        {
            Assembly assembly = typeof(AbstractEffect).Assembly;
            foreach (var type in assembly.GetTypes().SelectMany(x => x.GetMethods()).Where(m => m.GetCustomAttributes(typeof(EffectEnumAttribute), false).Length > 0).ToArray())
            {
                EffectEnumAttribute attr = (EffectEnumAttribute)type.GetCustomAttributes(typeof(EffectEnumAttribute), true)[0];
                Type stringType = Type.GetType(type.DeclaringType.FullName + ", " + assembly.GetName());

                var instance = Activator.CreateInstance(stringType, null); // instance d'une methode
                this.EffectsList.Add(attr.EffectsEnum, new EffectData(instance, type));

            }

            Console.WriteLine("{0} spell effect(s) initialized.", this.EffectsList.Count);
        }

        public List<NetworkMessage> BuildEffect(Fighter caster, Fighter target, EffectInstanceDice effect, List<NetworkMessage> queueMessage)
        {
            if (!this.EffectsList.ContainsKey((EffectsEnum)effect.EffectId))
            {
                Console.WriteLine("{0} effect not managed.", (EffectsEnum)effect.EffectId);
            }
            else
            {
                var method = this.EffectsList[(EffectsEnum)effect.EffectId];
                method.Methode.Invoke(method.Instance, new object[] { caster, target, effect, queueMessage });
            }

            return queueMessage;
        }
    }
}
