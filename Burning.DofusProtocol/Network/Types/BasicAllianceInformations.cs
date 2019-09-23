using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class BasicAllianceInformations : AbstractSocialGroupInfos
  {
    public new const uint Id = 419;
    public uint allianceId;
    public string allianceTag;

    public override uint TypeId
    {
      get
      {
        return 419;
      }
    }

    public BasicAllianceInformations()
    {
    }

    public BasicAllianceInformations(uint allianceId, string allianceTag)
    {
      this.allianceId = allianceId;
      this.allianceTag = allianceTag;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element allianceId.");
      writer.WriteVarInt((int) this.allianceId);
      writer.WriteUTF(this.allianceTag);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.allianceId = reader.ReadVarUhInt();
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element of BasicAllianceInformations.allianceId.");
      this.allianceTag = reader.ReadUTF();
    }
  }
}
