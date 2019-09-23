using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterReplayWithRemodelRequestMessage : CharacterReplayRequestMessage
  {
    public new const uint Id = 6551;
    public RemodelingInformation remodel;

    public override uint MessageId
    {
      get
      {
        return 6551;
      }
    }

    public CharacterReplayWithRemodelRequestMessage()
    {
    }

    public CharacterReplayWithRemodelRequestMessage(
      double characterId,
      RemodelingInformation remodel)
      : base(characterId)
    {
      this.remodel = remodel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.remodel.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.remodel = new RemodelingInformation();
      this.remodel.Deserialize(reader);
    }
  }
}
