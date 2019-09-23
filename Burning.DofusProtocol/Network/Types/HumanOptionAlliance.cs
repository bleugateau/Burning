using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionAlliance : HumanOption
  {
    public new const uint Id = 425;
    public AllianceInformations allianceInformations;
    public uint aggressable;

    public override uint TypeId
    {
      get
      {
        return 425;
      }
    }

    public HumanOptionAlliance()
    {
    }

    public HumanOptionAlliance(AllianceInformations allianceInformations, uint aggressable)
    {
      this.allianceInformations = allianceInformations;
      this.aggressable = aggressable;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.allianceInformations.Serialize(writer);
      writer.WriteByte((byte) this.aggressable);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.allianceInformations = new AllianceInformations();
      this.allianceInformations.Deserialize(reader);
      this.aggressable = (uint) reader.ReadByte();
      if (this.aggressable < 0U)
        throw new Exception("Forbidden value (" + (object) this.aggressable + ") on element of HumanOptionAlliance.aggressable.");
    }
  }
}
