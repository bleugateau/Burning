using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismInfoJoinLeaveRequestMessage : NetworkMessage
  {
    public const uint Id = 5844;
    public bool join;

    public override uint MessageId
    {
      get
      {
        return 5844;
      }
    }

    public PrismInfoJoinLeaveRequestMessage()
    {
    }

    public PrismInfoJoinLeaveRequestMessage(bool join)
    {
      this.join = join;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.join);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.join = reader.ReadBoolean();
    }
  }
}
