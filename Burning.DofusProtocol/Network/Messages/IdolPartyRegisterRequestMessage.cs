using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdolPartyRegisterRequestMessage : NetworkMessage
  {
    public const uint Id = 6582;
    public bool register;

    public override uint MessageId
    {
      get
      {
        return 6582;
      }
    }

    public IdolPartyRegisterRequestMessage()
    {
    }

    public IdolPartyRegisterRequestMessage(bool register)
    {
      this.register = register;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.register);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.register = reader.ReadBoolean();
    }
  }
}
