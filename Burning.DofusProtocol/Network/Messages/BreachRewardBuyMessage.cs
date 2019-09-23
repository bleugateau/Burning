using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachRewardBuyMessage : NetworkMessage
  {
    public const uint Id = 6803;
    public uint id;

    public override uint MessageId
    {
      get
      {
        return 6803;
      }
    }

    public BreachRewardBuyMessage()
    {
    }

    public BreachRewardBuyMessage(uint id)
    {
      this.id = id;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarInt((int) this.id);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadVarUhInt();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of BreachRewardBuyMessage.id.");
    }
  }
}
