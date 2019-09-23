using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class BasicGuildInformations : AbstractSocialGroupInfos
  {
    public new const uint Id = 365;
    public uint guildId;
    public string guildName;
    public uint guildLevel;

    public override uint TypeId
    {
      get
      {
        return 365;
      }
    }

    public BasicGuildInformations()
    {
    }

    public BasicGuildInformations(uint guildId, string guildName, uint guildLevel)
    {
      this.guildId = guildId;
      this.guildName = guildName;
      this.guildLevel = guildLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element guildId.");
      writer.WriteVarInt((int) this.guildId);
      writer.WriteUTF(this.guildName);
      if (this.guildLevel < 0U || this.guildLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.guildLevel + ") on element guildLevel.");
      writer.WriteByte((byte) this.guildLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guildId = reader.ReadVarUhInt();
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of BasicGuildInformations.guildId.");
      this.guildName = reader.ReadUTF();
      this.guildLevel = (uint) reader.ReadByte();
      if (this.guildLevel < 0U || this.guildLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.guildLevel + ") on element of BasicGuildInformations.guildLevel.");
    }
  }
}
