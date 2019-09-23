using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkMulticraftCustomerMessage : NetworkMessage
  {
    public const uint Id = 5817;
    public uint skillId;
    public uint crafterJobLevel;

    public override uint MessageId
    {
      get
      {
        return 5817;
      }
    }

    public ExchangeStartOkMulticraftCustomerMessage()
    {
    }

    public ExchangeStartOkMulticraftCustomerMessage(uint skillId, uint crafterJobLevel)
    {
      this.skillId = skillId;
      this.crafterJobLevel = crafterJobLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarInt((int) this.skillId);
      if (this.crafterJobLevel < 0U || this.crafterJobLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.crafterJobLevel + ") on element crafterJobLevel.");
      writer.WriteByte((byte) this.crafterJobLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.skillId = reader.ReadVarUhInt();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of ExchangeStartOkMulticraftCustomerMessage.skillId.");
      this.crafterJobLevel = (uint) reader.ReadByte();
      if (this.crafterJobLevel < 0U || this.crafterJobLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.crafterJobLevel + ") on element of ExchangeStartOkMulticraftCustomerMessage.crafterJobLevel.");
    }
  }
}
