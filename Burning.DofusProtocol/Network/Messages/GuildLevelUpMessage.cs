using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildLevelUpMessage : NetworkMessage
  {
    public const uint Id = 6062;
    public uint newLevel;

    public override uint MessageId
    {
      get
      {
        return 6062;
      }
    }

    public GuildLevelUpMessage()
    {
    }

    public GuildLevelUpMessage(uint newLevel)
    {
      this.newLevel = newLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.newLevel < 2U || this.newLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.newLevel + ") on element newLevel.");
      writer.WriteByte((byte) this.newLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.newLevel = (uint) reader.ReadByte();
      if (this.newLevel < 2U || this.newLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.newLevel + ") on element of GuildLevelUpMessage.newLevel.");
    }
  }
}
