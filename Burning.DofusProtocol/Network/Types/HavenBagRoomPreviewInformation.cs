using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burning.DofusProtocol.Network.Types
{
    public class HavenBagRoomPreviewInformation
    {

        public uint roomId = 0;

        public uint themeId = 0;

        public virtual uint TypeId
        {
            get
            {
                return 576;
            }
        }

        public HavenBagRoomPreviewInformation()
        {
        }

        public HavenBagRoomPreviewInformation(uint roomId, uint themeId)
        {
            this.roomId = roomId;
            this.themeId = themeId;
        }

        public virtual void Serialize(IDataWriter writer)
        {
            if (this.roomId < 0 || this.roomId > 255)
            {
                throw new Exception("Forbidden value (" + this.roomId + ") on element roomId.");
            }
            writer.WriteByte((byte)this.roomId);
            writer.WriteByte((byte)this.themeId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            this.roomId = reader.ReadByte();
            if (this.roomId < 0 || this.roomId > 255)
            {
                throw new Exception("Forbidden value (" + this.roomId + ") on element of HavenBagRoomPreviewInformation.roomId.");
            }
            this.themeId = reader.ReadByte();
        }
    }
}
