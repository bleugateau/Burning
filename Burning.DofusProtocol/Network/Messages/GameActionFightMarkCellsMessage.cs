using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5540;
    public GameActionMark mark;

    public override uint MessageId
    {
      get
      {
        return 5540;
      }
    }

    public GameActionFightMarkCellsMessage()
    {
    }

    public GameActionFightMarkCellsMessage(uint actionId, double sourceId, GameActionMark mark)
      : base(actionId, sourceId)
    {
      this.mark = mark;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.mark.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.mark = new GameActionMark();
      this.mark.Deserialize(reader);
    }
  }
}
