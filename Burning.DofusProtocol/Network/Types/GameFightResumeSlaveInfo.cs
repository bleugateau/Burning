using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightResumeSlaveInfo
  {
    public List<GameFightSpellCooldown> spellCooldowns = new List<GameFightSpellCooldown>();
    public const uint Id = 364;
    public double slaveId;
    public uint summonCount;
    public uint bombCount;

    public virtual uint TypeId
    {
      get
      {
        return 364;
      }
    }

    public GameFightResumeSlaveInfo()
    {
    }

    public GameFightResumeSlaveInfo(
      double slaveId,
      List<GameFightSpellCooldown> spellCooldowns,
      uint summonCount,
      uint bombCount)
    {
      this.slaveId = slaveId;
      this.spellCooldowns = spellCooldowns;
      this.summonCount = summonCount;
      this.bombCount = bombCount;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.slaveId < -9.00719925474099E+15 || this.slaveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.slaveId + ") on element slaveId.");
      writer.WriteDouble(this.slaveId);
      writer.WriteShort((short) this.spellCooldowns.Count);
      for (int index = 0; index < this.spellCooldowns.Count; ++index)
        this.spellCooldowns[index].Serialize(writer);
      if (this.summonCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.summonCount + ") on element summonCount.");
      writer.WriteByte((byte) this.summonCount);
      if (this.bombCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.bombCount + ") on element bombCount.");
      writer.WriteByte((byte) this.bombCount);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.slaveId = reader.ReadDouble();
      if (this.slaveId < -9.00719925474099E+15 || this.slaveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.slaveId + ") on element of GameFightResumeSlaveInfo.slaveId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameFightSpellCooldown fightSpellCooldown = new GameFightSpellCooldown();
        fightSpellCooldown.Deserialize(reader);
        this.spellCooldowns.Add(fightSpellCooldown);
      }
      this.summonCount = (uint) reader.ReadByte();
      if (this.summonCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.summonCount + ") on element of GameFightResumeSlaveInfo.summonCount.");
      this.bombCount = (uint) reader.ReadByte();
      if (this.bombCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.bombCount + ") on element of GameFightResumeSlaveInfo.bombCount.");
    }
  }
}
