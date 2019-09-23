using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DecraftResultMessage : NetworkMessage
  {
    public List<DecraftedItemStackInfo> results = new List<DecraftedItemStackInfo>();
    public const uint Id = 6569;

    public override uint MessageId
    {
      get
      {
        return 6569;
      }
    }

    public DecraftResultMessage()
    {
    }

    public DecraftResultMessage(List<DecraftedItemStackInfo> results)
    {
      this.results = results;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.results.Count);
      for (int index = 0; index < this.results.Count; ++index)
        this.results[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        DecraftedItemStackInfo decraftedItemStackInfo = new DecraftedItemStackInfo();
        decraftedItemStackInfo.Deserialize(reader);
        this.results.Add(decraftedItemStackInfo);
      }
    }
  }
}
