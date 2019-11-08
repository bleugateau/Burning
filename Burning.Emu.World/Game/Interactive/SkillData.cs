using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Burning.Emu.World.Game.Interactive
{
    public class SkillData
    {
        public object Instance;
        public int SkillId;
        public ConstructorInfo Constructor;

        public SkillData(object instance, int skillId, ConstructorInfo constructor)
        {
            this.Instance = instance;
            this.SkillId = skillId;
            this.Constructor = constructor;
        }
    }
}
