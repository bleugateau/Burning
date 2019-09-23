using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
  {
    public new const uint Id = 457;
    public uint firstNameId;
    public uint lastNameId;

    public override uint TypeId
    {
      get
      {
        return 457;
      }
    }

    public GameFightFighterTaxCollectorLightInformations()
    {
    }

    public GameFightFighterTaxCollectorLightInformations(
      double id,
      uint wave,
      uint level,
      int breed,
      bool sex,
      bool alive,
      uint firstNameId,
      uint lastNameId)
      : base(id, wave, level, breed, sex, alive)
    {
      this.firstNameId = firstNameId;
      this.lastNameId = lastNameId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element firstNameId.");
      writer.WriteVarShort((short) this.firstNameId);
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element lastNameId.");
      writer.WriteVarShort((short) this.lastNameId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.firstNameId = (uint) reader.ReadVarUhShort();
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element of GameFightFighterTaxCollectorLightInformations.firstNameId.");
      this.lastNameId = (uint) reader.ReadVarUhShort();
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element of GameFightFighterTaxCollectorLightInformations.lastNameId.");
    }
  }
}
