using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachRewardsMessage : NetworkMessage
  {
    public List<BreachReward> rewards = new List<BreachReward>();
    public const uint Id = 6813;
    public BreachReward save;

    public override uint MessageId
    {
      get
      {
        return 6813;
      }
    }

    public BreachRewardsMessage()
    {
    }

    public BreachRewardsMessage(List<BreachReward> rewards, BreachReward save)
    {
      this.rewards = rewards;
      this.save = save;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.rewards.Count);
      for (int index = 0; index < this.rewards.Count; ++index)
        this.rewards[index].Serialize(writer);
      this.save.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        BreachReward breachReward = new BreachReward();
        breachReward.Deserialize(reader);
        this.rewards.Add(breachReward);
      }
      this.save = new BreachReward();
      this.save.Deserialize(reader);
    }
  }
}
