using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LivingObjectMessageRequestMessage : NetworkMessage
  {
    public List<string> parameters = new List<string>();
    public const uint Id = 6066;
    public uint msgId;
    public uint livingObject;

    public override uint MessageId
    {
      get
      {
        return 6066;
      }
    }

    public LivingObjectMessageRequestMessage()
    {
    }

    public LivingObjectMessageRequestMessage(
      uint msgId,
      List<string> parameters,
      uint livingObject)
    {
      this.msgId = msgId;
      this.parameters = parameters;
      this.livingObject = livingObject;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element msgId.");
      writer.WriteVarShort((short) this.msgId);
      writer.WriteShort((short) this.parameters.Count);
      for (int index = 0; index < this.parameters.Count; ++index)
        writer.WriteUTF(this.parameters[index]);
      if (this.livingObject < 0U)
        throw new Exception("Forbidden value (" + (object) this.livingObject + ") on element livingObject.");
      writer.WriteVarInt((int) this.livingObject);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.msgId = (uint) reader.ReadVarUhShort();
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element of LivingObjectMessageRequestMessage.msgId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.parameters.Add(reader.ReadUTF());
      this.livingObject = reader.ReadVarUhInt();
      if (this.livingObject < 0U)
        throw new Exception("Forbidden value (" + (object) this.livingObject + ") on element of LivingObjectMessageRequestMessage.livingObject.");
    }
  }
}
