using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
  {
    public new const uint Id = 5999;
    public ObjectItemNotInContainer objectInfo;

    public override uint MessageId
    {
      get
      {
        return 5999;
      }
    }

    public ExchangeCraftResultWithObjectDescMessage()
    {
    }

    public ExchangeCraftResultWithObjectDescMessage(
      uint craftResult,
      ObjectItemNotInContainer objectInfo)
      : base(craftResult)
    {
      this.objectInfo = objectInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.objectInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectInfo = new ObjectItemNotInContainer();
      this.objectInfo.Deserialize(reader);
    }
  }
}
