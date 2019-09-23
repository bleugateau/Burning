using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightOptionToggleMessage : NetworkMessage
  {
    public const uint Id = 707;
    public uint option;

    public override uint MessageId
    {
      get
      {
        return 707;
      }
    }

    public GameFightOptionToggleMessage()
    {
    }

    public GameFightOptionToggleMessage(uint option)
    {
      this.option = option;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.option);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.option = (uint) reader.ReadByte();
      if (this.option < 0U)
        throw new Exception("Forbidden value (" + (object) this.option + ") on element of GameFightOptionToggleMessage.option.");
    }
  }
}
