using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GoldItem : Item
  {
    public new const uint Id = 123;
    public double sum;

    public override uint TypeId
    {
      get
      {
        return 123;
      }
    }

    public GoldItem()
    {
    }

    public GoldItem(double sum)
    {
      this.sum = sum;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.sum < 0.0 || this.sum > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sum + ") on element sum.");
      writer.WriteVarLong((long) this.sum);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.sum = (double) reader.ReadVarUhLong();
      if (this.sum < 0.0 || this.sum > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sum + ") on element of GoldItem.sum.");
    }
  }
}
