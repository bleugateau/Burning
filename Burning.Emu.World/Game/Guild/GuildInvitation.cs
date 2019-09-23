using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Guild
{
    public class GuildInvitation
    {
        public int GuildId { get; set; }

        public int SenderId { get; set; }

        public int TargetId { get; set; }

        public GuildInvitation(int guildId, int senderId, int targetId)
        {
            this.GuildId = guildId;
            this.SenderId = senderId;
            this.TargetId = targetId;
        }
    }
}
