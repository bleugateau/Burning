using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NicknameRefusedMessage : NetworkMessage
  {
    public const uint Id = 5638;
    public uint reason;

    public override uint MessageId
    {
      get
      {
        return 5638;
      }
    }

    public NicknameRefusedMessage()
    {
    }

    public NicknameRefusedMessage(uint reason)
    {
      this.reason = reason;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.reason);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.reason = (uint) reader.ReadByte();
      if (this.reason < 0U)
        throw new Exception("Forbidden value (" + (object) this.reason + ") on element of NicknameRefusedMessage.reason.");
    }
  }
}
