using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
  {
    public new const uint Id = 6000;
    public uint objectGenericId;

    public override uint MessageId
    {
      get
      {
        return 6000;
      }
    }

    public ExchangeCraftResultWithObjectIdMessage()
    {
    }

    public ExchangeCraftResultWithObjectIdMessage(uint craftResult, uint objectGenericId)
      : base(craftResult)
    {
      this.objectGenericId = objectGenericId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGenericId + ") on element objectGenericId.");
      writer.WriteVarShort((short) this.objectGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectGenericId = (uint) reader.ReadVarUhShort();
      if (this.objectGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGenericId + ") on element of ExchangeCraftResultWithObjectIdMessage.objectGenericId.");
    }
  }
}
