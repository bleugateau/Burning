using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SequencedoubleMessage : NetworkMessage
  {
    public const uint Id = 6317;
    public uint number;

    public override uint MessageId
    {
      get
      {
        return 6317;
      }
    }

    public SequencedoubleMessage()
    {
    }

    public SequencedoubleMessage(uint number)
    {
      this.number = number;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.number < 0U || this.number > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.number + ") on element number.");
      writer.WriteShort((short) this.number);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.number = (uint) reader.ReadUShort();
      if (this.number < 0U || this.number > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.number + ") on element of SequencedoubleMessage.number.");
    }
  }
}
