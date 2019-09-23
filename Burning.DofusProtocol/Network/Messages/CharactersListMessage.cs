using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharactersListMessage : BasicCharactersListMessage
  {
    public new const uint Id = 151;
    public bool hasStartupActions;

    public override uint MessageId
    {
      get
      {
        return 151;
      }
    }

    public CharactersListMessage()
    {
    }

    public CharactersListMessage(List<CharacterBaseInformations> characters, bool hasStartupActions)
      : base(characters)
    {
      this.hasStartupActions = hasStartupActions;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.hasStartupActions);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.hasStartupActions = reader.ReadBoolean();
    }
  }
}
