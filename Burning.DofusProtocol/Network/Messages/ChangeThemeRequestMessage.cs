using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChangeThemeRequestMessage : NetworkMessage
  {
    public const uint Id = 6639;
    public int theme;

    public override uint MessageId
    {
      get
      {
        return 6639;
      }
    }

    public ChangeThemeRequestMessage()
    {
    }

    public ChangeThemeRequestMessage(int theme)
    {
      this.theme = theme;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.theme);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.theme = (int) reader.ReadByte();
    }
  }
}
