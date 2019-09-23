using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TextInformationMessage : NetworkMessage
  {
    public List<string> parameters = new List<string>();
    public const uint Id = 780;
    public uint msgType;
    public uint msgId;

    public override uint MessageId
    {
      get
      {
        return 780;
      }
    }

    public TextInformationMessage()
    {
    }

    public TextInformationMessage(uint msgType, uint msgId, List<string> parameters)
    {
      this.msgType = msgType;
      this.msgId = msgId;
      this.parameters = parameters;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.msgType);
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element msgId.");
      writer.WriteVarShort((short) this.msgId);
      writer.WriteShort((short) this.parameters.Count);
      for (int index = 0; index < this.parameters.Count; ++index)
        writer.WriteUTF(this.parameters[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.msgType = (uint) reader.ReadByte();
      if (this.msgType < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgType + ") on element of TextInformationMessage.msgType.");
      this.msgId = (uint) reader.ReadVarUhShort();
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element of TextInformationMessage.msgId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.parameters.Add(reader.ReadUTF());
    }
  }
}
