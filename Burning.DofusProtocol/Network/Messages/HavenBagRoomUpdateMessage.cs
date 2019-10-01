using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
    public class HavenBagRoomUpdateMessage : NetworkMessage
    {
        public const uint Id = 6860;
        public uint action;
      
        public List<HavenBagRoomPreviewInformation> roomsPreview;

        public override uint MessageId
        {
            get
            {
                return 6860;
            }
        }

        public HavenBagRoomUpdateMessage()
        {
        }

        public HavenBagRoomUpdateMessage(uint actionId, List<HavenBagRoomPreviewInformation> roomsPreview)
        {
            this.action = actionId;
            this.roomsPreview = roomsPreview;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte((byte)this.action);
            writer.WriteShort((short)this.roomsPreview.Count);
            for (int _i2 = 0; _i2 < this.roomsPreview.Count; _i2++)
            {
                (this.roomsPreview[_i2] as HavenBagRoomPreviewInformation).Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            this.roomsPreview = new List<HavenBagRoomPreviewInformation>();
            this.action = reader.ReadByte();
            uint _roomsPreviewLen = reader.ReadUShort();
            for (int _i2 = 0; _i2 < _roomsPreviewLen; _i2++)
            {
                var room = new HavenBagRoomPreviewInformation();
                room.Deserialize(reader);
                this.roomsPreview.Add(room);
            }
        }
    }
}

