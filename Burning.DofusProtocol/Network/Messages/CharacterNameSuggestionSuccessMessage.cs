using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterNameSuggestionSuccessMessage : NetworkMessage
  {
    public const uint Id = 5544;
    public string suggestion;

    public override uint MessageId
    {
      get
      {
        return 5544;
      }
    }

    public CharacterNameSuggestionSuccessMessage()
    {
    }

    public CharacterNameSuggestionSuccessMessage(string suggestion)
    {
      this.suggestion = suggestion;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.suggestion);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.suggestion = reader.ReadUTF();
    }
  }
}
