using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachKickResponseMessage : NetworkMessage
  {
    public const uint Id = 6789;
    public CharacterMinimalInformations target;
    public bool kicked;

    public override uint MessageId
    {
      get
      {
        return 6789;
      }
    }

    public BreachKickResponseMessage()
    {
    }

    public BreachKickResponseMessage(CharacterMinimalInformations target, bool kicked)
    {
      this.target = target;
      this.kicked = kicked;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.target.Serialize(writer);
      writer.WriteBoolean(this.kicked);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.target = new CharacterMinimalInformations();
      this.target.Deserialize(reader);
      this.kicked = reader.ReadBoolean();
    }
  }
}
