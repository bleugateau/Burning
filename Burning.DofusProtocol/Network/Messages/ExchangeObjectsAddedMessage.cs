using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectsAddedMessage : ExchangeObjectMessage
  {
    public List<ObjectItem> @object = new List<ObjectItem>();
    public new const uint Id = 6535;

    public override uint MessageId
    {
      get
      {
        return 6535;
      }
    }

    public ExchangeObjectsAddedMessage()
    {
    }

    public ExchangeObjectsAddedMessage(bool remote, List<ObjectItem> @object)
      : base(remote)
    {
      this.@object = @object;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.@object.Count);
      for (int index = 0; index < this.@object.Count; ++index)
        this.@object[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItem objectItem = new ObjectItem();
        objectItem.Deserialize(reader);
        this.@object.Add(objectItem);
      }
    }
  }
}
