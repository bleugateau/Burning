using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterSelectionWithRemodelMessage : CharacterSelectionMessage
  {
    public new const uint Id = 6549;
    public RemodelingInformation remodel;

    public override uint MessageId
    {
      get
      {
        return 6549;
      }
    }

    public CharacterSelectionWithRemodelMessage()
    {
    }

    public CharacterSelectionWithRemodelMessage(double id, RemodelingInformation remodel)
      : base(id)
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
