using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class WrapperObjectErrorMessage : SymbioticObjectErrorMessage
  {
    public new const uint Id = 6529;

    public override uint MessageId
    {
      get
      {
        return 6529;
      }
    }

    public WrapperObjectErrorMessage()
    {
    }

    public WrapperObjectErrorMessage(int reason, int errorCode)
      : base(reason, errorCode)
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
