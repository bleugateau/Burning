using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LockableCodeResultMessage : NetworkMessage
  {
    public const uint Id = 5672;
    public uint result;

    public override uint MessageId
    {
      get
      {
        return 5672;
      }
    }

    public LockableCodeResultMessage()
    {
    }

    public LockableCodeResultMessage(uint result)
    {
      this.result = result;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.result);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.result = (uint) reader.ReadByte();
      if (this.result < 0U)
        throw new Exception("Forbidden value (" + (object) this.result + ") on element of LockableCodeResultMessage.result.");
    }
  }
}
