using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NewMailMessage : MailStatusMessage
  {
    public List<uint> sendersAccountId = new List<uint>();
    public new const uint Id = 6292;

    public override uint MessageId
    {
      get
      {
        return 6292;
      }
    }

    public NewMailMessage()
    {
    }

    public NewMailMessage(uint unread, uint total, List<uint> sendersAccountId)
      : base(unread, total)
    {
      this.sendersAccountId = sendersAccountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.sendersAccountId.Count);
      for (int index = 0; index < this.sendersAccountId.Count; ++index)
      {
        if (this.sendersAccountId[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.sendersAccountId[index] + ") on element 1 (starting at 1) of sendersAccountId.");
        writer.WriteInt((int) this.sendersAccountId[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of sendersAccountId.");
        this.sendersAccountId.Add(num2);
      }
    }
  }
}
