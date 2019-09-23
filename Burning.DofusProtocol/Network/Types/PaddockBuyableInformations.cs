using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PaddockBuyableInformations
  {
    public const uint Id = 130;
    public double price;
    public bool locked;

    public virtual uint TypeId
    {
      get
      {
        return 130;
      }
    }

    public PaddockBuyableInformations()
    {
    }

    public PaddockBuyableInformations(double price, bool locked)
    {
      this.price = price;
      this.locked = locked;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
      writer.WriteBoolean(this.locked);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of PaddockBuyableInformations.price.");
      this.locked = reader.ReadBoolean();
    }
  }
}
