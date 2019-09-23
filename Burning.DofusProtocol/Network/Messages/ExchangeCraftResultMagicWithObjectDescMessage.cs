using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftResultMagicWithObjectDescMessage : ExchangeCraftResultWithObjectDescMessage
  {
    public new const uint Id = 6188;
    public int magicPoolStatus;

    public override uint MessageId
    {
      get
      {
        return 6188;
      }
    }

    public ExchangeCraftResultMagicWithObjectDescMessage()
    {
    }

    public ExchangeCraftResultMagicWithObjectDescMessage(
      uint craftResult,
      ObjectItemNotInContainer objectInfo,
      int magicPoolStatus)
      : base(craftResult, objectInfo)
    {
      this.magicPoolStatus = magicPoolStatus;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.magicPoolStatus);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.magicPoolStatus = (int) reader.ReadByte();
    }
  }
}
