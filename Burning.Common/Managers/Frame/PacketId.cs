using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Managers.Frame
{
    public class PacketId : Attribute
    {
        public uint MessageId { get; set; }

        public PacketId(uint id)
        {
            this.MessageId = id;
        }
    }
}
