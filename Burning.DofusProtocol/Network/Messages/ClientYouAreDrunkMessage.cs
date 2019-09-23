using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ClientYouAreDrunkMessage : DebugInClientMessage
  {
    public new const uint Id = 6594;

    public override uint MessageId
    {
      get
      {
        return 6594;
      }
    }

    public ClientYouAreDrunkMessage()
    {
    }

    public ClientYouAreDrunkMessage(uint level, string message)
      : base(level, message)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
