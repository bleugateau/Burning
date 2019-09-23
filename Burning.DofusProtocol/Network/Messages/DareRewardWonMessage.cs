using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareRewardWonMessage : NetworkMessage
  {
    public const uint Id = 6678;
    public DareReward reward;

    public override uint MessageId
    {
      get
      {
        return 6678;
      }
    }

    public DareRewardWonMessage()
    {
    }

    public DareRewardWonMessage(DareReward reward)
    {
      this.reward = reward;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.reward.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.reward = new DareReward();
      this.reward.Deserialize(reader);
    }
  }
}
