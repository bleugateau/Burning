using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
  {
    public new const uint Id = 5885;

    public override uint MessageId
    {
      get
      {
        return 5885;
      }
    }

    public HouseLockFromInsideRequestMessage()
    {
    }

    public HouseLockFromInsideRequestMessage(string code)
      : base(code)
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
