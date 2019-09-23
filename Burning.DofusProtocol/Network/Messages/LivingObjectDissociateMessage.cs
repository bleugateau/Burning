using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LivingObjectDissociateMessage : NetworkMessage
  {
    public const uint Id = 5723;
    public uint livingUID;
    public uint livingPosition;

    public override uint MessageId
    {
      get
      {
        return 5723;
      }
    }

    public LivingObjectDissociateMessage()
    {
    }

    public LivingObjectDissociateMessage(uint livingUID, uint livingPosition)
    {
      this.livingUID = livingUID;
      this.livingPosition = livingPosition;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.livingUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.livingUID + ") on element livingUID.");
      writer.WriteVarInt((int) this.livingUID);
      if (this.livingPosition < 0U || this.livingPosition > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.livingPosition + ") on element livingPosition.");
      writer.WriteByte((byte) this.livingPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.livingUID = reader.ReadVarUhInt();
      if (this.livingUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.livingUID + ") on element of LivingObjectDissociateMessage.livingUID.");
      this.livingPosition = (uint) reader.ReadByte();
      if (this.livingPosition < 0U || this.livingPosition > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.livingPosition + ") on element of LivingObjectDissociateMessage.livingPosition.");
    }
  }
}
