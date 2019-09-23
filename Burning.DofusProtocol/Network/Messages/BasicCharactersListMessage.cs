using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicCharactersListMessage : NetworkMessage
  {
    public List<CharacterBaseInformations> characters = new List<CharacterBaseInformations>();
    public const uint Id = 6475;

    public override uint MessageId
    {
      get
      {
        return 6475;
      }
    }

    public BasicCharactersListMessage()
    {
    }

    public BasicCharactersListMessage(List<CharacterBaseInformations> characters)
    {
      this.characters = characters;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.characters.Count);
      for (int index = 0; index < this.characters.Count; ++index)
      {
        writer.WriteShort((short) this.characters[index].TypeId);
        this.characters[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        CharacterBaseInformations instance = ProtocolTypeManager.GetInstance<CharacterBaseInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.characters.Add(instance);
      }
    }
  }
}
