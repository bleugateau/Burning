using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MimicryObjectAssociatedMessage : SymbioticObjectAssociatedMessage
  {
    public new const uint Id = 6462;

    public override uint MessageId
    {
      get
      {
        return 6462;
      }
    }

    public MimicryObjectAssociatedMessage()
    {
    }

    public MimicryObjectAssociatedMessage(uint hostUID)
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
