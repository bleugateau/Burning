using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightStateUpdateMessage : NetworkMessage
  {
    public const uint Id = 6040;
    public uint state;

    public override uint MessageId
    {
      get
      {
        return 6040;
      }
    }

    public PrismFightStateUpdateMessage()
    {
    }

    public PrismFightStateUpdateMessage(uint state)
    {
      this.state = state;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element state.");
      writer.WriteByte((byte) this.state);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.state = (uint) reader.ReadByte();
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element of PrismFightStateUpdateMessage.state.");
    }
  }
}
