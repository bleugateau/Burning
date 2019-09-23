using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameDataPaddockObjectListAddMessage : NetworkMessage
  {
    public List<PaddockItem> paddockItemDescription = new List<PaddockItem>();
    public const uint Id = 5992;

    public override uint MessageId
    {
      get
      {
        return 5992;
      }
    }

    public GameDataPaddockObjectListAddMessage()
    {
    }

    public GameDataPaddockObjectListAddMessage(List<PaddockItem> paddockItemDescription)
    {
      this.paddockItemDescription = paddockItemDescription;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.paddockItemDescription.Count);
      for (int index = 0; index < this.paddockItemDescription.Count; ++index)
        this.paddockItemDescription[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PaddockItem paddockItem = new PaddockItem();
        paddockItem.Deserialize(reader);
        this.paddockItemDescription.Add(paddockItem);
      }
    }
  }
}
