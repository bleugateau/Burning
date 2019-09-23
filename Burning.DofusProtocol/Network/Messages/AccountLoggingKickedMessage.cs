using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AccountLoggingKickedMessage : NetworkMessage
  {
    public const uint Id = 6029;
    public uint days;
    public uint hours;
    public uint minutes;

    public override uint MessageId
    {
      get
      {
        return 6029;
      }
    }

    public AccountLoggingKickedMessage()
    {
    }

    public AccountLoggingKickedMessage(uint days, uint hours, uint minutes)
    {
      this.days = days;
      this.hours = hours;
      this.minutes = minutes;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.days < 0U)
        throw new Exception("Forbidden value (" + (object) this.days + ") on element days.");
      writer.WriteVarShort((short) this.days);
      if (this.hours < 0U)
        throw new Exception("Forbidden value (" + (object) this.hours + ") on element hours.");
      writer.WriteByte((byte) this.hours);
      if (this.minutes < 0U)
        throw new Exception("Forbidden value (" + (object) this.minutes + ") on element minutes.");
      writer.WriteByte((byte) this.minutes);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.days = (uint) reader.ReadVarUhShort();
      if (this.days < 0U)
        throw new Exception("Forbidden value (" + (object) this.days + ") on element of AccountLoggingKickedMessage.days.");
      this.hours = (uint) reader.ReadByte();
      if (this.hours < 0U)
        throw new Exception("Forbidden value (" + (object) this.hours + ") on element of AccountLoggingKickedMessage.hours.");
      this.minutes = (uint) reader.ReadByte();
      if (this.minutes < 0U)
        throw new Exception("Forbidden value (" + (object) this.minutes + ") on element of AccountLoggingKickedMessage.minutes.");
    }
  }
}
