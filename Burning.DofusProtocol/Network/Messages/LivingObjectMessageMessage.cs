using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LivingObjectMessageMessage : NetworkMessage
  {
    public const uint Id = 6065;
    public uint msgId;
    public uint timeStamp;
    public string owner;
    public uint objectGenericId;

    public override uint MessageId
    {
      get
      {
        return 6065;
      }
    }

    public LivingObjectMessageMessage()
    {
    }

    public LivingObjectMessageMessage(
      uint msgId,
      uint timeStamp,
      string owner,
      uint objectGenericId)
    {
      this.msgId = msgId;
      this.timeStamp = timeStamp;
      this.owner = owner;
      this.objectGenericId = objectGenericId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element msgId.");
      writer.WriteVarShort((short) this.msgId);
      if (this.timeStamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeStamp + ") on element timeStamp.");
      writer.WriteInt((int) this.timeStamp);
      writer.WriteUTF(this.owner);
      if (this.objectGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGenericId + ") on element objectGenericId.");
      writer.WriteVarShort((short) this.objectGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.msgId = (uint) reader.ReadVarUhShort();
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element of LivingObjectMessageMessage.msgId.");
      this.timeStamp = (uint) reader.ReadInt();
      if (this.timeStamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeStamp + ") on element of LivingObjectMessageMessage.timeStamp.");
      this.owner = reader.ReadUTF();
      this.objectGenericId = (uint) reader.ReadVarUhShort();
      if (this.objectGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGenericId + ") on element of LivingObjectMessageMessage.objectGenericId.");
    }
  }
}
