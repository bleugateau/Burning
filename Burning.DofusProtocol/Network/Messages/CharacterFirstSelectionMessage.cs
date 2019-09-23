using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterFirstSelectionMessage : CharacterSelectionMessage
  {
    public new const uint Id = 6084;
    public bool doTutorial;

    public override uint MessageId
    {
      get
      {
        return 6084;
      }
    }

    public CharacterFirstSelectionMessage()
    {
    }

    public CharacterFirstSelectionMessage(double id, bool doTutorial)
      : base(id)
    {
      this.doTutorial = doTutorial;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.doTutorial);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.doTutorial = reader.ReadBoolean();
    }
  }
}
