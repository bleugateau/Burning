using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightFighterMonsterLightInformations : GameFightFighterLightInformations
  {
    public new const uint Id = 455;
    public uint creatureGenericId;

    public override uint TypeId
    {
      get
      {
        return 455;
      }
    }

    public GameFightFighterMonsterLightInformations()
    {
    }

    public GameFightFighterMonsterLightInformations(
      double id,
      uint wave,
      uint level,
      int breed,
      bool sex,
      bool alive,
      uint creatureGenericId)
      : base(id, wave, level, breed, sex, alive)
    {
      this.creatureGenericId = creatureGenericId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.creatureGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGenericId + ") on element creatureGenericId.");
      writer.WriteVarShort((short) this.creatureGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.creatureGenericId = (uint) reader.ReadVarUhShort();
      if (this.creatureGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGenericId + ") on element of GameFightFighterMonsterLightInformations.creatureGenericId.");
    }
  }
}
