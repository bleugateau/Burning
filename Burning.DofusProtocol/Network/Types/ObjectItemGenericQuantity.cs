using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemGenericQuantity : Item
  {
    public new const uint Id = 483;
    public uint objectGID;
    public uint quantity;

    public override uint TypeId
    {
      get
      {
        return 483;
      }
    }

    public ObjectItemGenericQuantity()
    {
    }

    public ObjectItemGenericQuantity(uint objectGID, uint quantity)
    {
      this.objectGID = objectGID;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ObjectItemGenericQuantity.objectGID.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectItemGenericQuantity.quantity.");
    }
  }
}
