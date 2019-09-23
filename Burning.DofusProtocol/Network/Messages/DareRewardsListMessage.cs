using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareRewardsListMessage : NetworkMessage
  {
    public List<DareReward> rewards = new List<DareReward>();
    public const uint Id = 6677;

    public override uint MessageId
    {
      get
      {
        return 6677;
      }
    }

    public DareRewardsListMessage()
    {
    }

    public DareRewardsListMessage(List<DareReward> rewards)
    {
      this.rewards = rewards;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.rewards.Count);
      for (int index = 0; index < this.rewards.Count; ++index)
        this.rewards[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        DareReward dareReward = new DareReward();
        dareReward.Deserialize(reader);
        this.rewards.Add(dareReward);
      }
    }
  }
}
