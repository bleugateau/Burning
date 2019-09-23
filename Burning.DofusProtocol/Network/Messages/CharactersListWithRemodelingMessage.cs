using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharactersListWithRemodelingMessage : CharactersListMessage
  {
    public List<CharacterToRemodelInformations> charactersToRemodel = new List<CharacterToRemodelInformations>();
    public new const uint Id = 6550;

    public override uint MessageId
    {
      get
      {
        return 6550;
      }
    }

    public CharactersListWithRemodelingMessage()
    {
    }

    public CharactersListWithRemodelingMessage(
      List<CharacterBaseInformations> characters,
      bool hasStartupActions,
      List<CharacterToRemodelInformations> charactersToRemodel)
      : base(characters, hasStartupActions)
    {
      this.charactersToRemodel = charactersToRemodel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.charactersToRemodel.Count);
      for (int index = 0; index < this.charactersToRemodel.Count; ++index)
        this.charactersToRemodel[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        CharacterToRemodelInformations remodelInformations = new CharacterToRemodelInformations();
        remodelInformations.Deserialize(reader);
        this.charactersToRemodel.Add(remodelInformations);
      }
    }
  }
}
