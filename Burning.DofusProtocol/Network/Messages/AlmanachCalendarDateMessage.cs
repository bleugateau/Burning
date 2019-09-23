using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AlmanachCalendarDateMessage : NetworkMessage
  {
    public const uint Id = 6341;
    public int date;

    public override uint MessageId
    {
      get
      {
        return 6341;
      }
    }

    public AlmanachCalendarDateMessage()
    {
    }

    public AlmanachCalendarDateMessage(int date)
    {
      this.date = date;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.date);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.date = reader.ReadInt();
    }
  }
}
