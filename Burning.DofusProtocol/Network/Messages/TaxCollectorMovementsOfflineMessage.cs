using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorMovementsOfflineMessage : NetworkMessage
  {
    public List<TaxCollectorMovement> movements = new List<TaxCollectorMovement>();
    public const uint Id = 6611;

    public override uint MessageId
    {
      get
      {
        return 6611;
      }
    }

    public TaxCollectorMovementsOfflineMessage()
    {
    }

    public TaxCollectorMovementsOfflineMessage(List<TaxCollectorMovement> movements)
    {
      this.movements = movements;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.movements.Count);
      for (int index = 0; index < this.movements.Count; ++index)
        this.movements[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        TaxCollectorMovement collectorMovement = new TaxCollectorMovement();
        collectorMovement.Deserialize(reader);
        this.movements.Add(collectorMovement);
      }
    }
  }
}
