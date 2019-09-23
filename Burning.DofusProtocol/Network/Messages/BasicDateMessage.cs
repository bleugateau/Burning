using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicDateMessage : NetworkMessage
  {
    public const uint Id = 177;
    public uint day;
    public uint month;
    public uint year;

    public override uint MessageId
    {
      get
      {
        return 177;
      }
    }

    public BasicDateMessage()
    {
    }

    public BasicDateMessage(uint day, uint month, uint year)
    {
      this.day = day;
      this.month = month;
      this.year = year;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.day < 0U)
        throw new Exception("Forbidden value (" + (object) this.day + ") on element day.");
      writer.WriteByte((byte) this.day);
      if (this.month < 0U)
        throw new Exception("Forbidden value (" + (object) this.month + ") on element month.");
      writer.WriteByte((byte) this.month);
      if (this.year < 0U)
        throw new Exception("Forbidden value (" + (object) this.year + ") on element year.");
      writer.WriteShort((short) this.year);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.day = (uint) reader.ReadByte();
      if (this.day < 0U)
        throw new Exception("Forbidden value (" + (object) this.day + ") on element of BasicDateMessage.day.");
      this.month = (uint) reader.ReadByte();
      if (this.month < 0U)
        throw new Exception("Forbidden value (" + (object) this.month + ") on element of BasicDateMessage.month.");
      this.year = (uint) reader.ReadShort();
      if (this.year < 0U)
        throw new Exception("Forbidden value (" + (object) this.year + ") on element of BasicDateMessage.year.");
    }
  }
}
