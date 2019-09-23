using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class SendClickMessage : NetworkMessage
  {
    public const uint Id = 7990;
    public int X;
    public int Y;
    public int Delay;
    public bool DoubleClick;
    public bool Value;
    public bool RightClick;

    public override uint MessageId
    {
      get
      {
        return 7990;
      }
    }

    public SendClickMessage()
    {
    }

    public SendClickMessage(
      int x,
      int y,
      int delay,
      bool doubleClick,
      bool value,
      bool rightClick)
    {
      this.X = x;
      this.Y = y;
      this.Delay = delay;
      this.DoubleClick = doubleClick;
      this.Value = value;
      this.RightClick = rightClick;
    }

    public override void Deserialize(IDataReader reader)
    {
      this.X = reader.ReadInt();
      this.Y = reader.ReadInt();
      this.Delay = reader.ReadInt();
      this.DoubleClick = reader.ReadBoolean();
      this.Value = reader.ReadBoolean();
      this.RightClick = reader.ReadBoolean();
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.X);
      writer.WriteInt(this.Y);
      writer.WriteInt(this.Delay);
      writer.WriteBoolean(this.DoubleClick);
      writer.WriteBoolean(this.Value);
      writer.WriteBoolean(this.RightClick);
    }
  }
}
