using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AdditionalTaxCollectorInformations
  {
    public const uint Id = 165;
    public string collectorCallerName;
    public uint date;

    public virtual uint TypeId
    {
      get
      {
        return 165;
      }
    }

    public AdditionalTaxCollectorInformations()
    {
    }

    public AdditionalTaxCollectorInformations(string collectorCallerName, uint date)
    {
      this.collectorCallerName = collectorCallerName;
      this.date = date;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.collectorCallerName);
      if (this.date < 0U)
        throw new Exception("Forbidden value (" + (object) this.date + ") on element date.");
      writer.WriteInt((int) this.date);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.collectorCallerName = reader.ReadUTF();
      this.date = (uint) reader.ReadInt();
      if (this.date < 0U)
        throw new Exception("Forbidden value (" + (object) this.date + ") on element of AdditionalTaxCollectorInformations.date.");
    }
  }
}
