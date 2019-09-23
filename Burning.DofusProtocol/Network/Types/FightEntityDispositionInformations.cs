using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightEntityDispositionInformations : EntityDispositionInformations
  {
    public new const uint Id = 217;
    public double carryingCharacterId;

    public override uint TypeId
    {
      get
      {
        return 217;
      }
    }

    public FightEntityDispositionInformations()
    {
    }

    public FightEntityDispositionInformations(
      int cellId,
      uint direction,
      double carryingCharacterId)
      : base(cellId, direction)
    {
      this.carryingCharacterId = carryingCharacterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.carryingCharacterId < -9.00719925474099E+15 || this.carryingCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.carryingCharacterId + ") on element carryingCharacterId.");
      writer.WriteDouble(this.carryingCharacterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.carryingCharacterId = reader.ReadDouble();
      if (this.carryingCharacterId < -9.00719925474099E+15 || this.carryingCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.carryingCharacterId + ") on element of FightEntityDispositionInformations.carryingCharacterId.");
    }
  }
}
