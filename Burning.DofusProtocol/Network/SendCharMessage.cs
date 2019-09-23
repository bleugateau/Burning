using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class SendCharMessage : NetworkMessage
  {
    public const uint Id = 7993;
    public char Text;
    public int Delay;

    public override uint MessageId
    {
      get
      {
        return 7993;
      }
    }

    public SendCharMessage()
    {
    }

    public SendCharMessage(char text, int delay)
    {
      this.Text = text;
      this.Delay = delay;
    }

    public override void Deserialize(IDataReader reader)
    {
      this.Text = reader.ReadChar();
      this.Delay = reader.ReadInt();
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteChar(this.Text);
      writer.WriteInt(this.Delay);
    }
  }
}
