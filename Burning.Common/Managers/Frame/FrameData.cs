using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Burning.Common.Managers.Frame
{
    public class FrameData
    {
        public object Instance;
        public uint PacketId;
        public MethodInfo Methode;

        public FrameData(object instance, uint packetId, MethodInfo method)
        {
            this.Instance = instance;
            this.PacketId = packetId;
            this.Methode = method;
        }
    }
}
