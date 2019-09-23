using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicStatMessage : NetworkMessage
  {
    public const uint Id = 6530;
    public double timeSpent;
    public uint statId;

    public override uint MessageId
    {
      get
      {
        return 6530;
      }
    }

    public BasicStatMessage()
    {
    }

    public BasicStatMessage(double timeSpent, uint statId)
    {
      this.timeSpent = timeSpent;
      this.statId = statId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.timeSpent < 0.0 || this.timeSpent > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.timeSpent + ") on element timeSpent.");
      writer.WriteDouble(this.timeSpent);
      writer.WriteVarShort((short) this.statId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.timeSpent = reader.ReadDouble();
      if (this.timeSpent < 0.0 || this.timeSpent > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.timeSpent + ") on element of BasicStatMessage.timeSpent.");
      this.statId = (uint) reader.ReadVarUhShort();
      if (this.statId < 0U)
        throw new Exception("Forbidden value (" + (object) this.statId + ") on element of BasicStatMessage.statId.");
    }
  }
}
