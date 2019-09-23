using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IgnoredDeleteRequestMessage : NetworkMessage
  {
    public const uint Id = 5680;
    public uint accountId;
    public bool session;

    public override uint MessageId
    {
      get
      {
        return 5680;
      }
    }

    public IgnoredDeleteRequestMessage()
    {
    }

    public IgnoredDeleteRequestMessage(uint accountId, bool session)
    {
      this.accountId = accountId;
      this.session = session;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      writer.WriteBoolean(this.session);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of IgnoredDeleteRequestMessage.accountId.");
      this.session = reader.ReadBoolean();
    }
  }
}
