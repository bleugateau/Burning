using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
  {
    public new const uint Id = 372;
    public double kamas;
    public double experience;
    public uint pods;
    public double itemsValue;

    public override uint TypeId
    {
      get
      {
        return 372;
      }
    }

    public TaxCollectorLootInformations()
    {
    }

    public TaxCollectorLootInformations(
      double kamas,
      double experience,
      uint pods,
      double itemsValue)
    {
      this.kamas = kamas;
      this.experience = experience;
      this.pods = pods;
      this.itemsValue = itemsValue;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element kamas.");
      writer.WriteVarLong((long) this.kamas);
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteVarLong((long) this.experience);
      if (this.pods < 0U)
        throw new Exception("Forbidden value (" + (object) this.pods + ") on element pods.");
      writer.WriteVarInt((int) this.pods);
      if (this.itemsValue < 0.0 || this.itemsValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.itemsValue + ") on element itemsValue.");
      writer.WriteVarLong((long) this.itemsValue);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.kamas = (double) reader.ReadVarUhLong();
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element of TaxCollectorLootInformations.kamas.");
      this.experience = (double) reader.ReadVarUhLong();
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of TaxCollectorLootInformations.experience.");
      this.pods = reader.ReadVarUhInt();
      if (this.pods < 0U)
        throw new Exception("Forbidden value (" + (object) this.pods + ") on element of TaxCollectorLootInformations.pods.");
      this.itemsValue = (double) reader.ReadVarUhLong();
      if (this.itemsValue < 0.0 || this.itemsValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.itemsValue + ") on element of TaxCollectorLootInformations.itemsValue.");
    }
  }
}
