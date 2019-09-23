using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeReadyMessage : NetworkMessage
  {
    public const uint Id = 5511;
    public bool ready;
    public uint step;

    public override uint MessageId
    {
      get
      {
        return 5511;
      }
    }

    public ExchangeReadyMessage()
    {
    }

    public ExchangeReadyMessage(bool ready, uint step)
    {
      this.ready = ready;
      this.step = step;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.ready);
      if (this.step < 0U)
        throw new Exception("Forbidden value (" + (object) this.step + ") on element step.");
      writer.WriteVarShort((short) this.step);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.ready = reader.ReadBoolean();
      this.step = (uint) reader.ReadVarUhShort();
      if (this.step < 0U)
        throw new Exception("Forbidden value (" + (object) this.step + ") on element of ExchangeReadyMessage.step.");
    }
  }
}
