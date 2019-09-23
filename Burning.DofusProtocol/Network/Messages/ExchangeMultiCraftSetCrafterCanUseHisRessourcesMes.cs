using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : NetworkMessage
  {
    public const uint Id = 6021;
    public bool allow;

    public override uint MessageId
    {
      get
      {
        return 6021;
      }
    }

    public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
    {
    }

    public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(bool allow)
    {
      this.allow = allow;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.allow);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.allow = reader.ReadBoolean();
    }
  }
}
