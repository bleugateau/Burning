using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class SendStringMessage : NetworkMessage
  {
    public const uint Id = 7992;
    public string Text;
    public int Delay;

    public override uint MessageId
    {
      get
      {
        return 7992;
      }
    }

    public SendStringMessage()
    {
    }

    public SendStringMessage(string text, int delay)
    {
      this.Text = text;
      this.Delay = delay;
    }

    public override void Deserialize(IDataReader reader)
    {
      this.Text = reader.ReadUTF();
      this.Delay = reader.ReadInt();
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.Text);
      writer.WriteInt(this.Delay);
    }
  }
}
