using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceKickRequestMessage : NetworkMessage
  {
    public const uint Id = 6400;
    public uint kickedId;

    public override uint MessageId
    {
      get
      {
        return 6400;
      }
    }

    public AllianceKickRequestMessage()
    {
    }

    public AllianceKickRequestMessage(uint kickedId)
    {
      this.kickedId = kickedId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.kickedId < 0U)
        throw new Exception("Forbidden value (" + (object) this.kickedId + ") on element kickedId.");
      writer.WriteVarInt((int) this.kickedId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.kickedId = reader.ReadVarUhInt();
      if (this.kickedId < 0U)
        throw new Exception("Forbidden value (" + (object) this.kickedId + ") on element of AllianceKickRequestMessage.kickedId.");
    }
  }
}
