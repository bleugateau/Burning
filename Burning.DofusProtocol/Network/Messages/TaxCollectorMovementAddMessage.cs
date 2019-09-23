using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorMovementAddMessage : NetworkMessage
  {
    public const uint Id = 5917;
    public TaxCollectorInformations informations;

    public override uint MessageId
    {
      get
      {
        return 5917;
      }
    }

    public TaxCollectorMovementAddMessage()
    {
    }

    public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
    {
      this.informations = informations;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.informations.TypeId);
      this.informations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.informations = ProtocolTypeManager.GetInstance<TaxCollectorInformations>((uint) reader.ReadUShort());
      this.informations.Deserialize(reader);
    }
  }
}
