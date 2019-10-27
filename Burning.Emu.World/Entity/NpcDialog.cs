using Burning.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{
    public class NpcDialog : AbstractEntity
    {
        public int NpcId { get; set; }

        public int MessageId { get; set; }

        public List<NpcReply> Replies { get; set; }
    }

    public class NpcReply
    {
        public int ReplyId { get; set; }

        public int NextMessageId { get; set; }

        public string Constraints { get; set; } //LVL>100|OBJECTID>4578

        public string ActionsResult { get; set; } //REMOVEOBJECTID=4578|ADDOBJECTID=789
    }
}
