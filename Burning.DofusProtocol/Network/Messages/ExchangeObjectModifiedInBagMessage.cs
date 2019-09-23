using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectModifiedInBagMessage : ExchangeObjectMessage
  {
    public new const uint Id = 6008;
    public ObjectItem @object;

    public override uint MessageId
    {
      get
      {
        return 6008;
      }
    }

    public ExchangeObjectModifiedInBagMessage()
    {
    }

    public ExchangeObjectModifiedInBagMessage(bool remote, ObjectItem @object)
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
