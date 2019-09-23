using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AbstractPartyEventMessage : AbstractPartyMessage
  {
    public new const uint Id = 6273;

    public override uint MessageId
    {
      get
      {
        return 6273;
      }
    }

    public AbstractPartyEventMessage()
    {
    }

    public AbstractPartyEventMessage(uint partyId)
      : base(partyId)
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
