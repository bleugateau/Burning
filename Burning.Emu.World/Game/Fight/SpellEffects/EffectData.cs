using Burning.Emu.World.Game.Fight.Fighters;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Effects
{
    public class EffectData
    {
        public object Instance;
        public MethodInfo Methode;

        public EffectData(object instance, MethodInfo method)
        {
            this.Instance = instance;
            this.Methode = method;
        }
    }
}
