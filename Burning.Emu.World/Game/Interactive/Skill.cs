using Burning.Emu.World.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Interactive
{
    public abstract class Skill
    {
        public WorldClient Client { get; set; }

        public int SkillId { get; set; }

        public Skill(int skillId, WorldClient client)
        {
            this.SkillId = skillId;
            this.Client = client;
        }

        public abstract void Execute();
    }
}
