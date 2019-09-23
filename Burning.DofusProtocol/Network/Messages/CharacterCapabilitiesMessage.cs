using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterCapabilitiesMessage : NetworkMessage
  {
    public const uint Id = 6339;
    public uint guildEmblemSymbolCategories;

    public override uint MessageId
    {
      get
      {
        return 6339;
      }
    }

    public CharacterCapabilitiesMessage()
    {
    }

    public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
    {
      this.guildEmblemSymbolCategories = guildEmblemSymbolCategories;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.guildEmblemSymbolCategories < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildEmblemSymbolCategories + ") on element guildEmblemSymbolCategories.");
      writer.WriteVarInt((int) this.guildEmblemSymbolCategories);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildEmblemSymbolCategories = reader.ReadVarUhInt();
      if (this.guildEmblemSymbolCategories < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildEmblemSymbolCategories + ") on element of CharacterCapabilitiesMessage.guildEmblemSymbolCategories.");
    }
  }
}
