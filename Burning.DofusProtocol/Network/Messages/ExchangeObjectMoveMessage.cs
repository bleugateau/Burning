using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectMoveMessage : NetworkMessage
  {
    public const uint Id = 5518;
    public uint objectUID;
    public int quantity;

    public override uint MessageId
    {
      get
      {
        return 5518;
      }
    }

    public ExchangeObjectMoveMessage()
    {
    }

    public ExchangeObjectMoveMessage(uint objectUID, int quantity)
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
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ExchangeObjectMoveMessage.objectUID.");
      this.quantity = reader.ReadVarInt();
    }
  }
}
