using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AbstractGameActionMessage : NetworkMessage
  {
    public const uint Id = 1000;
    public uint actionId;
    public double sourceId;

    public override uint MessageId
    {
      get
      {
        return 1000;
      }
    }

    public AbstractGameActionMessage()
    {
    }

    public AbstractGameActionMessage(uint actionId, double sourceId)
    {
      this.actionId = actionId;
      this.sourceId = sourceId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element actionId.");
      writer.WriteVarShort((short) this.actionId);
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element sourceId.");
      writer.WriteDouble(this.sourceId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.actionId = (uint) reader.ReadVarUhShort();
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element of AbstractGameActionMessage.actionId.");
      this.sourceId = reader.ReadDouble();
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element of AbstractGameActionMessage.sourceId.");
    }
  }
}
