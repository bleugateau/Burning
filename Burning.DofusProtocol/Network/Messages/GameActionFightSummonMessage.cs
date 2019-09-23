using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightSummonMessage : AbstractGameActionMessage
  {
    public List<GameFightFighterInformations> summons = new List<GameFightFighterInformations>();
    public new const uint Id = 5825;

    public override uint MessageId
    {
      get
      {
        return 5825;
      }
    }

    public GameActionFightSummonMessage()
    {
    }

    public GameActionFightSummonMessage(
      uint actionId,
      double sourceId,
      List<GameFightFighterInformations> summons)
      : base(actionId, sourceId)
    {
      this.summons = summons;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.summons.Count);
      for (int index = 0; index < this.summons.Count; ++index)
      {
        writer.WriteShort((short) this.summons[index].TypeId);
        this.summons[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameFightFighterInformations instance = ProtocolTypeManager.GetInstance<GameFightFighterInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.summons.Add(instance);
      }
    }
  }
}
