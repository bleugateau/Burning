using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class RefreshFollowedQuestsOrderRequestMessage : NetworkMessage
  {
    public List<uint> quests = new List<uint>();
    public const uint Id = 6722;

    public override uint MessageId
    {
      get
      {
        return 6722;
      }
    }

    public RefreshFollowedQuestsOrderRequestMessage()
    {
    }

    public RefreshFollowedQuestsOrderRequestMessage(List<uint> quests)
    {
      this.quests = quests;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.quests.Count);
      for (int index = 0; index < this.quests.Count; ++index)
      {
        if (this.quests[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.quests[index] + ") on element 1 (starting at 1) of quests.");
        writer.WriteVarShort((short) this.quests[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of quests.");
        this.quests.Add(num2);
      }
    }
  }
}
