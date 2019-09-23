using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameMapChangeOrientationRequestMessage : NetworkMessage
  {
    public const uint Id = 945;
    public uint direction;

    public override uint MessageId
    {
      get
      {
        return 945;
      }
    }

    public GameMapChangeOrientationRequestMessage()
    {
    }

    public GameMapChangeOrientationRequestMessage(uint direction)
    {
      this.direction = direction;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.direction);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.direction = (uint) reader.ReadByte();
      if (this.direction < 0U)
        throw new Exception("Forbidden value (" + (object) this.direction + ") on element of GameMapChangeOrientationRequestMessage.direction.");
    }
  }
}
