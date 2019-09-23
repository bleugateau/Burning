using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class WrapperObjectAssociatedMessage : SymbioticObjectAssociatedMessage
  {
    public new const uint Id = 6523;

    public override uint MessageId
    {
      get
      {
        return 6523;
      }
    }

    public WrapperObjectAssociatedMessage()
    {
    }

    public WrapperObjectAssociatedMessage(uint hostUID)
      : base(hostUID)
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
