using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicTimeMessage : NetworkMessage
  {
    public const uint Id = 175;
    public double timestamp;
    public int timezoneOffset;

    public override uint MessageId
    {
      get
      {
        return 175;
      }
    }

    public BasicTimeMessage()
    {
    }

    public BasicTimeMessage(double timestamp, int timezoneOffset)
    {
      this.timestamp = timestamp;
      this.timezoneOffset = timezoneOffset;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.timestamp < 0.0 || this.timestamp > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.timestamp + ") on element timestamp.");
      writer.WriteDouble(this.timestamp);
      writer.WriteShort((short) this.timezoneOffset);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.timestamp = reader.ReadDouble();
      if (this.timestamp < 0.0 || this.timestamp > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.timestamp + ") on element of BasicTimeMessage.timestamp.");
      this.timezoneOffset = (int) reader.ReadShort();
    }
  }
}
