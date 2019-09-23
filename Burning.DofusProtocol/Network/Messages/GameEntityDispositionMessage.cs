using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameEntityDispositionMessage : NetworkMessage
  {
    public const uint Id = 5693;
    public IdentifiedEntityDispositionInformations disposition;

    public override uint MessageId
    {
      get
      {
        return 5693;
      }
    }

    public GameEntityDispositionMessage()
    {
    }

    public GameEntityDispositionMessage(
      IdentifiedEntityDispositionInformations disposition)
    {
      this.disposition = disposition;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.disposition.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.disposition = new IdentifiedEntityDispositionInformations();
      this.disposition.Deserialize(reader);
    }
  }
}
