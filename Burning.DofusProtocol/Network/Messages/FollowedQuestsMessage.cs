using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FollowedQuestsMessage : NetworkMessage
  {
    public List<QuestActiveDetailedInformations> quests = new List<QuestActiveDetailedInformations>();
    public const uint Id = 6717;

    public override uint MessageId
    {
      get
      {
        return 6717;
      }
    }

    public FollowedQuestsMessage()
    {
    }

    public FollowedQuestsMessage(List<QuestActiveDetailedInformations> quests)
    {
      this.quests = quests;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.quests.Count);
      for (int index = 0; index < this.quests.Count; ++index)
        this.quests[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        QuestActiveDetailedInformations detailedInformations = new QuestActiveDetailedInformations();
        detailedInformations.Deserialize(reader);
        this.quests.Add(detailedInformations);
      }
    }
  }
}
