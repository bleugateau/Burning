using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
  {
    public new const uint Id = 107;
    public double id;

    public override uint TypeId
    {
      get
      {
        return 107;
      }
    }

    public IdentifiedEntityDispositionInformations()
    {
    }

    public IdentifiedEntityDispositionInformations(int cellId, uint direction, double id)
      : base(cellId, direction)
    {
      this.id = id;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of IdentifiedEntityDispositionInformations.id.");
    }
  }
}
