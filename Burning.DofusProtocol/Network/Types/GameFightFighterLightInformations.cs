using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightFighterLightInformations
  {
    public const uint Id = 413;
    public double id;
    public uint wave;
    public uint level;
    public int breed;
    public bool sex;
    public bool alive;

    public virtual uint TypeId
    {
      get
      {
        return 413;
      }
    }

    public GameFightFighterLightInformations()
    {
    }

    public GameFightFighterLightInformations(
      double id,
      uint wave,
      uint level,
      int breed,
      bool sex,
      bool alive)
    {
      this.id = id;
      this.wave = wave;
      this.level = level;
      this.breed = breed;
      this.sex = sex;
      this.alive = alive;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.sex), (byte) 1, this.alive);
      writer.WriteByte((byte) num);
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element wave.");
      writer.WriteByte((byte) this.wave);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      writer.WriteByte((byte) this.breed);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.sex = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.alive = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of GameFightFighterLightInformations.id.");
      this.wave = (uint) reader.ReadByte();
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element of GameFightFighterLightInformations.wave.");
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of GameFightFighterLightInformations.level.");
      this.breed = (int) reader.ReadByte();
    }
  }
}
