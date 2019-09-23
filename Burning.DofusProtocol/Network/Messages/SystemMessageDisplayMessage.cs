using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SystemMessageDisplayMessage : NetworkMessage
  {
    public List<string> parameters = new List<string>();
    public const uint Id = 189;
    public bool hangUp;
    public uint msgId;

    public override uint MessageId
    {
      get
      {
        return 189;
      }
    }

    public SystemMessageDisplayMessage()
    {
    }

    public SystemMessageDisplayMessage(bool hangUp, uint msgId, List<string> parameters)
    {
      this.hangUp = hangUp;
      this.msgId = msgId;
      this.parameters = parameters;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.hangUp);
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element msgId.");
      writer.WriteVarShort((short) this.msgId);
      writer.WriteShort((short) this.parameters.Count);
      for (int index = 0; index < this.parameters.Count; ++index)
        writer.WriteUTF(this.parameters[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.hangUp = reader.ReadBoolean();
      this.msgId = (uint) reader.ReadVarUhShort();
      if (this.msgId < 0U)
        throw new Exception("Forbidden value (" + (object) this.msgId + ") on element of SystemMessageDisplayMessage.msgId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.parameters.Add(reader.ReadUTF());
    }
  }
}
