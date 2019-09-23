using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class DareVersatileInformations
  {
    public const uint Id = 504;
    public double dareId;
    public uint countEntrants;
    public uint countWinners;

    public virtual uint TypeId
    {
      get
      {
        return 504;
      }
    }

    public DareVersatileInformations()
    {
    }

    public DareVersatileInformations(double dareId, uint countEntrants, uint countWinners)
    {
      this.dareId = dareId;
      this.countEntrants = countEntrants;
      this.countWinners = countWinners;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element dareId.");
      writer.WriteDouble(this.dareId);
      if (this.countEntrants < 0U)
        throw new Exception("Forbidden value (" + (object) this.countEntrants + ") on element countEntrants.");
      writer.WriteInt((int) this.countEntrants);
      if (this.countWinners < 0U)
        throw new Exception("Forbidden value (" + (object) this.countWinners + ") on element countWinners.");
      writer.WriteInt((int) this.countWinners);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.dareId = reader.ReadDouble();
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element of DareVersatileInformations.dareId.");
      this.countEntrants = (uint) reader.ReadInt();
      if (this.countEntrants < 0U)
        throw new Exception("Forbidden value (" + (object) this.countEntrants + ") on element of DareVersatileInformations.countEntrants.");
      this.countWinners = (uint) reader.ReadInt();
      if (this.countWinners < 0U)
        throw new Exception("Forbidden value (" + (object) this.countWinners + ") on element of DareVersatileInformations.countWinners.");
    }
  }
}
