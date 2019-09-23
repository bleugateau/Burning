using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportRequestMessage : NetworkMessage
  {
    public const uint Id = 5961;
    public uint sourceType;
    public uint destinationType;
    public double mapId;

    public override uint MessageId
    {
      get
      {
        return 5961;
      }
    }

    public TeleportRequestMessage()
    {
    }

    public TeleportRequestMessage(uint sourceType, uint destinationType, double mapId)
    {
      this.sourceType = sourceType;
      this.destinationType = destinationType;
      this.mapId = mapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.sourceType);
      writer.WriteByte((byte) this.destinationType);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.sourceType = (uint) reader.ReadByte();
      if (this.sourceType < 0U)
        throw new Exception("Forbidden value (" + (object) this.sourceType + ") on element of TeleportRequestMessage.sourceType.");
      this.destinationType = (uint) reader.ReadByte();
      if (this.destinationType < 0U)
        throw new Exception("Forbidden value (" + (object) this.destinationType + ") on element of TeleportRequestMessage.destinationType.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of TeleportRequestMessage.mapId.");
    }
  }
}
