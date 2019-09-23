using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObtainedItemWithBonusMessage : ObtainedItemMessage
  {
    public new const uint Id = 6520;
    public uint bonusQuantity;

    public override uint MessageId
    {
      get
      {
        return 6520;
      }
    }

    public ObtainedItemWithBonusMessage()
    {
    }

    public ObtainedItemWithBonusMessage(uint genericId, uint baseQuantity, uint bonusQuantity)
      : base(genericId, baseQuantity)
    {
      this.bonusQuantity = bonusQuantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.bonusQuantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.bonusQuantity + ") on element bonusQuantity.");
      writer.WriteVarInt((int) this.bonusQuantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.bonusQuantity = reader.ReadVarUhInt();
      if (this.bonusQuantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.bonusQuantity + ") on element of ObtainedItemWithBonusMessage.bonusQuantity.");
    }
  }
}
