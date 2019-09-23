using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectUseInWorkshopMessage : NetworkMessage
  {
    public const uint Id = 6004;
    public uint objectUID;
    public int quantity;

    public override uint MessageId
    {
      get
      {
        return 6004;
      }
    }

    public ExchangeObjectUseInWorkshopMessage()
    {
    }

    public ExchangeObjectUseInWorkshopMessage(uint objectUID, int quantity)
    {
      this.objectUID = objectUID;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      writer.WriteVarInt(this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ExchangeObjectUseInWorkshopMessage.objectUID.");
      this.quantity = reader.ReadVarInt();
    }
  }
}
