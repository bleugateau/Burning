using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachBudgetMessage : NetworkMessage
  {
    public const uint Id = 6786;
    public uint bugdet;

    public override uint MessageId
    {
      get
      {
        return 6786;
      }
    }

    public BreachBudgetMessage()
    {
    }

    public BreachBudgetMessage(uint bugdet)
    {
      this.bugdet = bugdet;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.bugdet < 0U)
        throw new Exception("Forbidden value (" + (object) this.bugdet + ") on element bugdet.");
      writer.WriteVarInt((int) this.bugdet);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.bugdet = reader.ReadVarUhInt();
      if (this.bugdet < 0U)
        throw new Exception("Forbidden value (" + (object) this.bugdet + ") on element of BreachBudgetMessage.bugdet.");
    }
  }
}
