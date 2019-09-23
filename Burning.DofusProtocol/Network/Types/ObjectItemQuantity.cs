using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemQuantity : Item
  {
    public new const uint Id = 119;
    public uint objectUID;
    public uint quantity;

    public override uint TypeId
    {
      get
      {
        return 119;
      }
    }

    public ObjectItemQuantity()
    {
    }

    public ObjectItemQuantity(uint objectUID, uint quantity)
    {
      this.objectUID = objectUID;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectItemQuantity.objectUID.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectItemQuantity.quantity.");
    }
  }
}
