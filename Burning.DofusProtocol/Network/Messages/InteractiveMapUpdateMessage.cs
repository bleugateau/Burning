using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InteractiveMapUpdateMessage : NetworkMessage
  {
    public List<InteractiveElement> interactiveElements = new List<InteractiveElement>();
    public const uint Id = 5002;

    public override uint MessageId
    {
      get
      {
        return 5002;
      }
    }

    public InteractiveMapUpdateMessage()
    {
    }

    public InteractiveMapUpdateMessage(List<InteractiveElement> interactiveElements)
    {
      this.interactiveElements = interactiveElements;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.interactiveElements.Count);
      for (int index = 0; index < this.interactiveElements.Count; ++index)
      {
        writer.WriteShort((short) this.interactiveElements[index].TypeId);
        this.interactiveElements[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        InteractiveElement instance = ProtocolTypeManager.GetInstance<InteractiveElement>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.interactiveElements.Add(instance);
      }
    }
  }
}
