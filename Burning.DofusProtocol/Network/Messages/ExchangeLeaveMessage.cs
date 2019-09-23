using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeLeaveMessage : LeaveDialogMessage
  {
    public new const uint Id = 5628;
    public bool success;

    public override uint MessageId
    {
      get
      {
        return 5628;
      }
    }

    public ExchangeLeaveMessage()
    {
    }

    public ExchangeLeaveMessage(uint dialogType, bool success)
      : base(dialogType)
    {
      this.success = success;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.success);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.success = reader.ReadBoolean();
    }
  }
}
