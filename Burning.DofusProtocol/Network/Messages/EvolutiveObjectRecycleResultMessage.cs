using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EvolutiveObjectRecycleResultMessage : NetworkMessage
  {
    public List<RecycledItem> recycledItems = new List<RecycledItem>();
    public const uint Id = 6779;

    public override uint MessageId
    {
      get
      {
        return 6779;
      }
    }

    public EvolutiveObjectRecycleResultMessage()
    {
    }

    public EvolutiveObjectRecycleResultMessage(List<RecycledItem> recycledItems)
    {
      this.recycledItems = recycledItems;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.recycledItems.Count);
      for (int index = 0; index < this.recycledItems.Count; ++index)
        this.recycledItems[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        RecycledItem recycledItem = new RecycledItem();
        recycledItem.Deserialize(reader);
        this.recycledItems.Add(recycledItem);
      }
    }
  }
}
