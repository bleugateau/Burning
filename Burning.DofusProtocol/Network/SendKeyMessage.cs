using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class SendKeyMessage : NetworkMessage
  {
    public const uint Id = 7991;
    public int Key;
    public int Delay;
    public bool KeyDown;
    public bool KeyUp;

    public override uint MessageId
    {
      get
      {
        return 7991;
      }
    }

    public bool NormalClick
    {
      get
      {
        if (!this.KeyDown)
          return !this.KeyUp;
        return false;
      }
    }

    public SendKeyMessage()
    {
    }

    public SendKeyMessage(int key, int delay, bool keyDown, bool keyUp)
    {
      this.Key = key;
      this.Delay = delay;
      this.KeyDown = keyDown;
      this.KeyUp = keyUp;
    }

    public override void Deserialize(IDataReader reader)
    {
      this.Key = reader.ReadInt();
      this.Delay = reader.ReadInt();
      this.KeyDown = reader.ReadBoolean();
      this.KeyUp = reader.ReadBoolean();
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.Key);
      writer.WriteInt(this.Delay);
      writer.WriteBoolean(this.KeyDown);
      writer.WriteBoolean(this.KeyUp);
    }
  }
}
