using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class MonsterBoosts
  {
    public const uint Id = 497;
    public uint id;
    public uint xpBoost;
    public uint dropBoost;

    public virtual uint TypeId
    {
      get
      {
        return 497;
      }
    }

    public MonsterBoosts()
    {
    }

    public MonsterBoosts(uint id, uint xpBoost, uint dropBoost)
    {
      this.id = id;
      this.xpBoost = xpBoost;
      this.dropBoost = dropBoost;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarInt((int) this.id);
      if (this.xpBoost < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpBoost + ") on element xpBoost.");
      writer.WriteVarShort((short) this.xpBoost);
      if (this.dropBoost < 0U)
        throw new Exception("Forbidden value (" + (object) this.dropBoost + ") on element dropBoost.");
      writer.WriteVarShort((short) this.dropBoost);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadVarUhInt();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of MonsterBoosts.id.");
      this.xpBoost = (uint) reader.ReadVarUhShort();
      if (this.xpBoost < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpBoost + ") on element of MonsterBoosts.xpBoost.");
      this.dropBoost = (uint) reader.ReadVarUhShort();
      if (this.dropBoost < 0U)
        throw new Exception("Forbidden value (" + (object) this.dropBoost + ") on element of MonsterBoosts.dropBoost.");
    }
  }
}
