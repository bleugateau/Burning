using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextCreateMessage : NetworkMessage
  {
    public const uint Id = 200;
    public uint context;

    public override uint MessageId
    {
      get
      {
        return 200;
      }
    }

    public GameContextCreateMessage()
    {
    }

    public GameContextCreateMessage(uint context)
    {
      this.context = context;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.context);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.context = (uint) reader.ReadByte();
      if (this.context < 0U)
        throw new Exception("Forbidden value (" + (object) this.context + ") on element of GameContextCreateMessage.context.");
    }
  }
}
