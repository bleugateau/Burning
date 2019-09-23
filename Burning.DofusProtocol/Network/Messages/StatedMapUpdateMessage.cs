using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StatedMapUpdateMessage : NetworkMessage
  {
    public List<StatedElement> statedElements = new List<StatedElement>();
    public const uint Id = 5716;

    public override uint MessageId
    {
      get
      {
        return 5716;
      }
    }

    public StatedMapUpdateMessage()
    {
    }

    public StatedMapUpdateMessage(List<StatedElement> statedElements)
    {
      this.statedElements = statedElements;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.statedElements.Count);
      for (int index = 0; index < this.statedElements.Count; ++index)
        this.statedElements[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        StatedElement statedElement = new StatedElement();
        statedElement.Deserialize(reader);
        this.statedElements.Add(statedElement);
      }
    }
  }
}
