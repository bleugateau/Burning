using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
  {
    public const uint Id = 5818;
    public uint skillId;

    public override uint MessageId
    {
      get
      {
        return 5818;
      }
    }

    public ExchangeStartOkMulticraftCrafterMessage()
    {
    }

    public ExchangeStartOkMulticraftCrafterMessage(uint skillId)
    {
      this.skillId = skillId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarInt((int) this.skillId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.skillId = reader.ReadVarUhInt();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of ExchangeStartOkMulticraftCrafterMessage.skillId.");
    }
  }
}
