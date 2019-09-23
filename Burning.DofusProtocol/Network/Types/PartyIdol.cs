using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyIdol : Idol
  {
    public List<double> ownersIds = new List<double>();
    public new const uint Id = 490;

    public override uint TypeId
    {
      get
      {
        return 490;
      }
    }

    public PartyIdol()
    {
    }

    public PartyIdol(uint id, uint xpBonusPercent, uint dropBonusPercent, List<double> ownersIds)
      : base(id, xpBonusPercent, dropBonusPercent)
    {
      this.ownersIds = ownersIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.ownersIds.Count);
      for (int index = 0; index < this.ownersIds.Count; ++index)
      {
        if (this.ownersIds[index] < 0.0 || this.ownersIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.ownersIds[index] + ") on element 1 (starting at 1) of ownersIds.");
        writer.WriteVarLong((long) this.ownersIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = (double) reader.ReadVarUhLong();
        if (num2 < 0.0 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ownersIds.");
        this.ownersIds.Add(num2);
      }
    }
  }
}
