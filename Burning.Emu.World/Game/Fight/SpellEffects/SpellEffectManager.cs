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
    public static class SpellEffectManager
    {
        private static Dictionary<EffectsEnum, EffectData> EffectsList = new Dictionary<EffectsEnum, EffectData>();

        public static void Initialize()
        {
            Assembly assembly = typeof(AbstractEffect).Assembly;
            foreach (var type in assembly.GetTypes().SelectMany(x => x.GetMethods()).Where(m => m.GetCustomAttributes(typeof(EffectEnumAttribute), false).Length > 0).ToArray())
            {
                EffectEnumAttribute attr = (EffectEnumAttribute)type.GetCustomAttributes(typeof(EffectEnumAttribute), true)[0];
                Type stringType = Type.GetType(type.DeclaringType.FullName + ", " + assembly.GetName());

                var instance = Activator.CreateInstance(stringType, null); // instance d'une methode
                EffectsList.Add(attr.EffectsEnum, new EffectData(instance, type));

            }

            Console.WriteLine("{0} spell effect(s) initialized.", EffectsList.Count);
        }

        public static List<NetworkMessage> BuildEffect(Fighter caster, Fighter target, SpellLevel spellLevel, List<NetworkMessage> queueMessage)
        {
            foreach (var effect in spellLevel.Effects)
            {
                if (!EffectsList.ContainsKey((EffectsEnum)effect.EffectId))
                {
                    Console.WriteLine("{0} effect not managed.", (EffectsEnum)effect.EffectId);
                    continue;
                }

                var method = EffectsList[(EffectsEnum)effect.EffectId];
                method.Methode.Invoke(method.Instance, new object[] { caster, target, effect, queueMessage });
            }

            return queueMessage;
        }
    }
}
