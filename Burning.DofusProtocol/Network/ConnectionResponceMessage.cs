using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class ConnectionResponceMessage : NetworkMessage
  {
    public const uint Id = 7986;

    public override uint MessageId
    {
      get
      {
        return 7986;
      }
    }

    public short ActionId { get; set; }

    public ConnectionResponceMessage()
    {
    }

    public ConnectionResponceMessage(int actionId)
    {
      this.ActionId = (short) actionId;
    }

    public override void Deserialize(IDataReader reader)
    {
      this.ActionId = reader.ReadShort();
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort(this.ActionId);
    }
  }
}
