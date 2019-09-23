using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectAddedMessage : ExchangeObjectMessage
  {
    public new const uint Id = 5516;
    public ObjectItem @object;

    public override uint MessageId
    {
      get
      {
        return 5516;
      }
    }

    public ExchangeObjectAddedMessage()
    {
    }

    public ExchangeObjectAddedMessage(bool remote, ObjectItem @object)
      : base(remote)
    {
      this.@object = @object;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.@object.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.@object = new ObjectItem();
      this.@object.Deserialize(reader);
    }
  }
}
