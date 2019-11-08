using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Interactive
{
    public class SkillAttribute : Attribute
    {
        public int SkillId { get; set; }

        public SkillAttribute(int skillId)
        {
            this.SkillId = skillId;
        }
    }
}
