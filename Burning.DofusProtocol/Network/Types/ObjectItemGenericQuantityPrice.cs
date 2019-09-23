using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemGenericQuantityPrice : ObjectItemGenericQuantity
  {
    public new const uint Id = 494;
    public double price;

    public override uint TypeId
    {
      get
      {
        return 494;
      }
    }

    public ObjectItemGenericQuantityPrice()
    {
    }

    public ObjectItemGenericQuantityPrice(uint objectGID, uint quantity, double price)
      : base(objectGID, quantity)
    {
      this.price = price;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of ObjectItemGenericQuantityPrice.price.");
    }
  }
}
