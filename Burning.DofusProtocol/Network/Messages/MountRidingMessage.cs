using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountRidingMessage : NetworkMessage
  {
    public const uint Id = 5967;
    public bool isRiding;
    public bool isAutopilot;

    public override uint MessageId
    {
      get
      {
        return 5967;
      }
    }

    public MountRidingMessage()
    {
    }

    public MountRidingMessage(bool isRiding, bool isAutopilot)
    {
      this.isRiding = isRiding;
      this.isAutopilot = isAutopilot;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.isRiding), (byte) 1, this.isAutopilot);
      writer.WriteByte((byte) num);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.isRiding = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.isAutopilot = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
    }
  }
}
