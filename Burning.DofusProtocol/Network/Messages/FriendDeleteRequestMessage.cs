using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendDeleteRequestMessage : NetworkMessage
  {
    public const uint Id = 5603;
    public uint accountId;

    public override uint MessageId
    {
      get
      {
        return 5603;
      }
    }

    public FriendDeleteRequestMessage()
    {
    }

    public FriendDeleteRequestMessage(uint accountId)
    {
      this.accountId = accountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of FriendDeleteRequestMessage.accountId.");
    }
  }
}
