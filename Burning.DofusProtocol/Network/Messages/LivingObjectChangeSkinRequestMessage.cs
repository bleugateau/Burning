using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LivingObjectChangeSkinRequestMessage : NetworkMessage
  {
    public const uint Id = 5725;
    public uint livingUID;
    public uint livingPosition;
    public uint skinId;

    public override uint MessageId
    {
      get
      {
        return 5725;
      }
    }

    public LivingObjectChangeSkinRequestMessage()
    {
    }

    public LivingObjectChangeSkinRequestMessage(uint livingUID, uint livingPosition, uint skinId)
    {
      this.livingUID = livingUID;
      this.livingPosition = livingPosition;
      this.skinId = skinId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.livingUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.livingUID + ") on element livingUID.");
      writer.WriteVarInt((int) this.livingUID);
      if (this.livingPosition < 0U || this.livingPosition > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.livingPosition + ") on element livingPosition.");
      writer.WriteByte((byte) this.livingPosition);
      if (this.skinId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skinId + ") on element skinId.");
      writer.WriteVarInt((int) this.skinId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.livingUID = reader.ReadVarUhInt();
      if (this.livingUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.livingUID + ") on element of LivingObjectChangeSkinRequestMessage.livingUID.");
      this.livingPosition = (uint) reader.ReadByte();
      if (this.livingPosition < 0U || this.livingPosition > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.livingPosition + ") on element of LivingObjectChangeSkinRequestMessage.livingPosition.");
      this.skinId = reader.ReadVarUhInt();
      if (this.skinId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skinId + ") on element of LivingObjectChangeSkinRequestMessage.skinId.");
    }
  }
}
