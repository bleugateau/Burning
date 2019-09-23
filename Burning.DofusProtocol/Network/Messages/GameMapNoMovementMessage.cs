using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameMapNoMovementMessage : NetworkMessage
  {
    public const uint Id = 954;
    public int cellX;
    public int cellY;

    public override uint MessageId
    {
      get
      {
        return 954;
      }
    }

    public GameMapNoMovementMessage()
    {
    }

    public GameMapNoMovementMessage(int cellX, int cellY)
    {
      this.cellX = cellX;
      this.cellY = cellY;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.cellX);
      writer.WriteShort((short) this.cellY);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.cellX = (int) reader.ReadShort();
      this.cellY = (int) reader.ReadShort();
    }
  }
}
