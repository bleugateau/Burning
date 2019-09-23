using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountHarnessColorsUpdateRequestMessage : NetworkMessage
  {
    public const uint Id = 6697;
    public bool useHarnessColors;

    public override uint MessageId
    {
      get
      {
        return 6697;
      }
    }

    public MountHarnessColorsUpdateRequestMessage()
    {
    }

    public MountHarnessColorsUpdateRequestMessage(bool useHarnessColors)
    {
      this.useHarnessColors = useHarnessColors;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.useHarnessColors);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.useHarnessColors = reader.ReadBoolean();
    }
  }
}
