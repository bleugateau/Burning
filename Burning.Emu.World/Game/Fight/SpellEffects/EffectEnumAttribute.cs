using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Effects
{
    public class EffectEnumAttribute : Attribute
    {
        public EffectsEnum EffectsEnum { get; set; }

        public EffectEnumAttribute(EffectsEnum effectsEnum)
        {
            this.EffectsEnum = effectsEnum;
        }
    }
}
