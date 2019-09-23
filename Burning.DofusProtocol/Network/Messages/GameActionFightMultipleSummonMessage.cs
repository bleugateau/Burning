using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightMultipleSummonMessage : AbstractGameActionMessage
  {
    public List<GameContextSummonsInformation> summons = new List<GameContextSummonsInformation>();
    public new const uint Id = 6837;

    public override uint MessageId
    {
      get
      {
        return 6837;
      }
    }

    public GameActionFightMultipleSummonMessage()
    {
    }

    public GameActionFightMultipleSummonMessage(
      uint actionId,
      double sourceId,
      List<GameContextSummonsInformation> summons)
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
        GameContextSummonsInformation instance = ProtocolTypeManager.GetInstance<GameContextSummonsInformation>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.summons.Add(instance);
      }
    }
  }
}
