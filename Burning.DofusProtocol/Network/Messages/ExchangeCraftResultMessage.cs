using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftResultMessage : NetworkMessage
  {
    public const uint Id = 5790;
    public uint craftResult;

    public override uint MessageId
    {
      get
      {
        return 5790;
      }
    }

    public ExchangeCraftResultMessage()
    {
    }

    public ExchangeCraftResultMessage(uint craftResult)
    {
      this.craftResult = craftResult;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.craftResult);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.craftResult = (uint) reader.ReadByte();
      if (this.craftResult < 0U)
        throw new Exception("Forbidden value (" + (object) this.craftResult + ") on element of ExchangeCraftResultMessage.craftResult.");
    }
  }
}
