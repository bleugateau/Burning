using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightFighterEntityLightInformation : GameFightFighterLightInformations
  {
    public new const uint Id = 548;
    public uint entityModelId;
    public double masterId;

    public override uint TypeId
    {
      get
      {
        return 548;
      }
    }

    public GameFightFighterEntityLightInformation()
    {
    }

    public GameFightFighterEntityLightInformation(
      double id,
      uint wave,
      uint level,
      int breed,
      bool sex,
      bool alive,
      uint entityModelId,
      double masterId)
      : base(id, wave, level, breed, sex, alive)
    {
      this.entityModelId = entityModelId;
      this.masterId = masterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.entityModelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.entityModelId + ") on element entityModelId.");
      writer.WriteByte((byte) this.entityModelId);
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element masterId.");
      writer.WriteDouble(this.masterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.entityModelId = (uint) reader.ReadByte();
      if (this.entityModelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.entityModelId + ") on element of GameFightFighterEntityLightInformation.entityModelId.");
      this.masterId = reader.ReadDouble();
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element of GameFightFighterEntityLightInformation.masterId.");
    }
  }
}
