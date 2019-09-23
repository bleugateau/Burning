using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamMemberInformations
  {
    public const uint Id = 44;
    public double id;

    public virtual uint TypeId
    {
      get
      {
        return 44;
      }
    }

    public FightTeamMemberInformations()
    {
    }

    public FightTeamMemberInformations(double id)
    {
      this.id = id;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of FightTeamMemberInformations.id.");
    }
  }
}
