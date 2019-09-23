using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MailStatusMessage : NetworkMessage
  {
    public const uint Id = 6275;
    public uint unread;
    public uint total;

    public override uint MessageId
    {
      get
      {
        return 6275;
      }
    }

    public MailStatusMessage()
    {
    }

    public MailStatusMessage(uint unread, uint total)
    {
      this.unread = unread;
      this.total = total;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.unread < 0U)
        throw new Exception("Forbidden value (" + (object) this.unread + ") on element unread.");
      writer.WriteVarShort((short) this.unread);
      if (this.total < 0U)
        throw new Exception("Forbidden value (" + (object) this.total + ") on element total.");
      writer.WriteVarShort((short) this.total);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.unread = (uint) reader.ReadVarUhShort();
      if (this.unread < 0U)
        throw new Exception("Forbidden value (" + (object) this.unread + ") on element of MailStatusMessage.unread.");
      this.total = (uint) reader.ReadVarUhShort();
      if (this.total < 0U)
        throw new Exception("Forbidden value (" + (object) this.total + ") on element of MailStatusMessage.total.");
    }
  }
}
