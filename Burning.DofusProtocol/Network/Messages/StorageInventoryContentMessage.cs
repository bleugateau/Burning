using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StorageInventoryContentMessage : InventoryContentMessage
  {
    public new const uint Id = 5646;

    public override uint MessageId
    {
      get
      {
        return 5646;
      }
    }

    public StorageInventoryContentMessage()
    {
    }

    public StorageInventoryContentMessage(List<ObjectItem> objects, double kamas)
      : base(objects, kamas)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
