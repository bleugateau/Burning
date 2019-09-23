using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
  {
    public new const uint Id = 387;
    public uint quantity;

    public override uint TypeId
    {
      get
      {
        return 387;
      }
    }

    public ObjectItemInformationWithQuantity()
    {
    }

    public ObjectItemInformationWithQuantity(
      uint objectGID,
      List<ObjectEffect> effects,
      uint quantity)
      : base(objectGID, effects)
    {
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectItemInformationWithQuantity.quantity.");
    }
  }
}
