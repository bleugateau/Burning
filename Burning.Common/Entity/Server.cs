using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class Server
    {
        public int Id { get; set; }

        public ushort ServerId { get; set; }
        
        public sbyte Status { get; set; }

        public Server() { }
    }
}
