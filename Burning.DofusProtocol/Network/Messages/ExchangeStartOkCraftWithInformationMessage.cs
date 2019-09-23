using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
  {
    public new const uint Id = 5941;
    public uint skillId;

    public override uint MessageId
    {
      get
      {
        return 5941;
      }
    }

    public ExchangeStartOkCraftWithInformationMessage()
    {
    }

    public ExchangeStartOkCraftWithInformationMessage(uint skillId)
    {
      this.skillId = skillId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarInt((int) this.skillId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.skillId = reader.ReadVarUhInt();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of ExchangeStartOkCraftWithInformationMessage.skillId.");
    }
  }
}
