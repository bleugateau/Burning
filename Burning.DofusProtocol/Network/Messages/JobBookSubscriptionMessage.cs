using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobBookSubscriptionMessage : NetworkMessage
  {
    public List<JobBookSubscription> subscriptions = new List<JobBookSubscription>();
    public const uint Id = 6593;

    public override uint MessageId
    {
      get
      {
        return 6593;
      }
    }

    public JobBookSubscriptionMessage()
    {
    }

    public JobBookSubscriptionMessage(List<JobBookSubscription> subscriptions)
    {
      this.subscriptions = subscriptions;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.subscriptions.Count);
      for (int index = 0; index < this.subscriptions.Count; ++index)
        this.subscriptions[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        JobBookSubscription bookSubscription = new JobBookSubscription();
        bookSubscription.Deserialize(reader);
        this.subscriptions.Add(bookSubscription);
      }
    }
  }
}
