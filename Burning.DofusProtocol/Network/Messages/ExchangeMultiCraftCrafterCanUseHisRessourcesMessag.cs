using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : NetworkMessage
  {
    public const uint Id = 6020;
    public bool allowed;

    public override uint MessageId
    {
      get
      {
        return 6020;
      }
    }

    public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
    {
    }

    public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(bool allowed)
    {
      this.allowed = allowed;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.allowed);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.allowed = reader.ReadBoolean();
    }
  }
}
