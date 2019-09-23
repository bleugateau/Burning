using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AdminQuietCommandMessage : AdminCommandMessage
  {
    public new const uint Id = 5662;

    public override uint MessageId
    {
      get
      {
        return 5662;
      }
    }

    public AdminQuietCommandMessage()
    {
    }

    public AdminQuietCommandMessage(string content)
      : base(content)
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
