using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AbstractTaxCollectorListMessage : NetworkMessage
  {
    public List<TaxCollectorInformations> informations = new List<TaxCollectorInformations>();
    public const uint Id = 6568;

    public override uint MessageId
    {
      get
      {
        return 6568;
      }
    }

    public AbstractTaxCollectorListMessage()
    {
    }

    public AbstractTaxCollectorListMessage(List<TaxCollectorInformations> informations)
    {
      this.informations = informations;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.informations.Count);
      for (int index = 0; index < this.informations.Count; ++index)
      {
        writer.WriteShort((short) this.informations[index].TypeId);
        this.informations[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        TaxCollectorInformations instance = ProtocolTypeManager.GetInstance<TaxCollectorInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.informations.Add(instance);
      }
    }
  }
}
