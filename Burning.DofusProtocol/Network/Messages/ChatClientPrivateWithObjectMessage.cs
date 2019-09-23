using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
  {
    public List<ObjectItem> objects = new List<ObjectItem>();
    public new const uint Id = 852;

    public override uint MessageId
    {
      get
      {
        return 852;
      }
    }

    public ChatClientPrivateWithObjectMessage()
    {
    }

    public ChatClientPrivateWithObjectMessage(
      string content,
      string receiver,
      List<ObjectItem> objects)
      : base(content, receiver)
    {
      this.objects = objects;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.objects.Count);
      for (int index = 0; index < this.objects.Count; ++index)
        this.objects[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItem objectItem = new ObjectItem();
        objectItem.Deserialize(reader);
        this.objects.Add(objectItem);
      }
    }
  }
}
