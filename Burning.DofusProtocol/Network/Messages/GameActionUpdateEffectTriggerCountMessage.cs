using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionUpdateEffectTriggerCountMessage : NetworkMessage
  {
    public List<GameFightEffectTriggerCount> targetIds = new List<GameFightEffectTriggerCount>();
    public const uint Id = 6838;

    public override uint MessageId
    {
      get
      {
        return 6838;
      }
    }

    public GameActionUpdateEffectTriggerCountMessage()
    {
    }

    public GameActionUpdateEffectTriggerCountMessage(List<GameFightEffectTriggerCount> targetIds)
    {
      this.targetIds = targetIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.targetIds.Count);
      for (int index = 0; index < this.targetIds.Count; ++index)
        this.targetIds[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameFightEffectTriggerCount effectTriggerCount = new GameFightEffectTriggerCount();
        effectTriggerCount.Deserialize(reader);
        this.targetIds.Add(effectTriggerCount);
      }
    }
  }
}
