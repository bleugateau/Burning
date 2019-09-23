using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObtainedItemMessage : NetworkMessage
  {
    public const uint Id = 6519;
    public uint genericId;
    public uint baseQuantity;

    public override uint MessageId
    {
      get
      {
        return 6519;
      }
    }

    public ObtainedItemMessage()
    {
    }

    public ObtainedItemMessage(uint genericId, uint baseQuantity)
    {
      this.genericId = genericId;
      this.baseQuantity = baseQuantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.genericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genericId + ") on element genericId.");
      writer.WriteVarShort((short) this.genericId);
      if (this.baseQuantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.baseQuantity + ") on element baseQuantity.");
      writer.WriteVarInt((int) this.baseQuantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.genericId = (uint) reader.ReadVarUhShort();
      if (this.genericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genericId + ") on element of ObtainedItemMessage.genericId.");
      this.baseQuantity = reader.ReadVarUhInt();
      if (this.baseQuantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.baseQuantity + ") on element of ObtainedItemMessage.baseQuantity.");
    }
  }
}
