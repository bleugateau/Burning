using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AcquaintancesListMessage : NetworkMessage
  {
    public List<AcquaintanceInformation> acquaintanceList = new List<AcquaintanceInformation>();
    public const uint Id = 6820;

    public override uint MessageId
    {
      get
      {
        return 6820;
      }
    }

    public AcquaintancesListMessage()
    {
    }

    public AcquaintancesListMessage(List<AcquaintanceInformation> acquaintanceList)
    {
      this.acquaintanceList = acquaintanceList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.acquaintanceList.Count);
      for (int index = 0; index < this.acquaintanceList.Count; ++index)
      {
        writer.WriteShort((short) this.acquaintanceList[index].TypeId);
        this.acquaintanceList[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        AcquaintanceInformation instance = ProtocolTypeManager.GetInstance<AcquaintanceInformation>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.acquaintanceList.Add(instance);
      }
    }
  }
}
