using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameDataPaddockObjectAddMessage : NetworkMessage
  {
    public const uint Id = 5990;
    public PaddockItem paddockItemDescription;

    public override uint MessageId
    {
      get
      {
        return 5990;
      }
    }

    public GameDataPaddockObjectAddMessage()
    {
    }

    public GameDataPaddockObjectAddMessage(PaddockItem paddockItemDescription)
    {
      this.paddockItemDescription = paddockItemDescription;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.paddockItemDescription.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.paddockItemDescription = new PaddockItem();
      this.paddockItemDescription.Deserialize(reader);
    }
  }
}
