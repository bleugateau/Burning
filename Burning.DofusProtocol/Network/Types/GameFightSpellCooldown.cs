using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightSpellCooldown
  {
    public const uint Id = 205;
    public int spellId;
    public uint cooldown;

    public virtual uint TypeId
    {
      get
      {
        return 205;
      }
    }

    public GameFightSpellCooldown()
    {
    }

    public GameFightSpellCooldown(int spellId, uint cooldown)
    {
      this.spellId = spellId;
      this.cooldown = cooldown;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.spellId);
      if (this.cooldown < 0U)
        throw new Exception("Forbidden value (" + (object) this.cooldown + ") on element cooldown.");
      writer.WriteByte((byte) this.cooldown);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.spellId = reader.ReadInt();
      this.cooldown = (uint) reader.ReadByte();
      if (this.cooldown < 0U)
        throw new Exception("Forbidden value (" + (object) this.cooldown + ") on element of GameFightSpellCooldown.cooldown.");
    }
  }
}
