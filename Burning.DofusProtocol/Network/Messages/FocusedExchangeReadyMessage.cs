using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FocusedExchangeReadyMessage : ExchangeReadyMessage
  {
    public new const uint Id = 6701;
    public uint focusActionId;

    public override uint MessageId
    {
      get
      {
        return 6701;
      }
    }

    public FocusedExchangeReadyMessage()
    {
    }

    public FocusedExchangeReadyMessage(bool ready, uint step, uint focusActionId)
      : base(ready, step)
    {
      this.focusActionId = focusActionId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.focusActionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.focusActionId + ") on element focusActionId.");
      writer.WriteVarInt((int) this.focusActionId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.focusActionId = reader.ReadVarUhInt();
      if (this.focusActionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.focusActionId + ") on element of FocusedExchangeReadyMessage.focusActionId.");
    }
  }
}
