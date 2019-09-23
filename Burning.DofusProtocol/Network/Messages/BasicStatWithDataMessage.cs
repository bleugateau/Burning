using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicStatWithDataMessage : BasicStatMessage
  {
    public List<StatisticData> datas = new List<StatisticData>();
    public new const uint Id = 6573;

    public override uint MessageId
    {
      get
      {
        return 6573;
      }
    }

    public BasicStatWithDataMessage()
    {
    }

    public BasicStatWithDataMessage(double timeSpent, uint statId, List<StatisticData> datas)
      : base(timeSpent, statId)
    {
      this.datas = datas;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.datas.Count);
      for (int index = 0; index < this.datas.Count; ++index)
      {
        writer.WriteShort((short) this.datas[index].TypeId);
        this.datas[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        StatisticData instance = ProtocolTypeManager.GetInstance<StatisticData>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.datas.Add(instance);
      }
    }
  }
}
