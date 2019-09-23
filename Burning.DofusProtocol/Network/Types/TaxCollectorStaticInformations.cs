using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorStaticInformations
  {
    public const uint Id = 147;
    public uint firstNameId;
    public uint lastNameId;
    public GuildInformations guildIdentity;

    public virtual uint TypeId
    {
      get
      {
        return 147;
      }
    }

    public TaxCollectorStaticInformations()
    {
    }

    public TaxCollectorStaticInformations(
      uint firstNameId,
      uint lastNameId,
      GuildInformations guildIdentity)
    {
      this.firstNameId = firstNameId;
      this.lastNameId = lastNameId;
      this.guildIdentity = guildIdentity;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element firstNameId.");
      writer.WriteVarShort((short) this.firstNameId);
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element lastNameId.");
      writer.WriteVarShort((short) this.lastNameId);
      this.guildIdentity.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.firstNameId = (uint) reader.ReadVarUhShort();
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element of TaxCollectorStaticInformations.firstNameId.");
      this.lastNameId = (uint) reader.ReadVarUhShort();
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element of TaxCollectorStaticInformations.lastNameId.");
      this.guildIdentity = new GuildInformations();
      this.guildIdentity.Deserialize(reader);
    }
  }
}
