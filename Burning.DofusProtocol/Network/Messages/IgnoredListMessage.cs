using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IgnoredListMessage : NetworkMessage
  {
    public List<IgnoredInformations> ignoredList = new List<IgnoredInformations>();
    public const uint Id = 5674;

    public override uint MessageId
    {
      get
      {
        return 5674;
      }
    }

    public IgnoredListMessage()
    {
    }

    public IgnoredListMessage(List<IgnoredInformations> ignoredList)
    {
      this.ignoredList = ignoredList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.ignoredList.Count);
      for (int index = 0; index < this.ignoredList.Count; ++index)
      {
        writer.WriteShort((short) this.ignoredList[index].TypeId);
        this.ignoredList[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        IgnoredInformations instance = ProtocolTypeManager.GetInstance<IgnoredInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.ignoredList.Add(instance);
      }
    }
  }
}
