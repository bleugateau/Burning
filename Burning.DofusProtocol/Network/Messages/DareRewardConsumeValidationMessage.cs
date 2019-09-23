using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareRewardConsumeValidationMessage : NetworkMessage
  {
    public const uint Id = 6675;
    public double dareId;
    public uint type;

    public override uint MessageId
    {
      get
      {
        return 6675;
      }
    }

    public DareRewardConsumeValidationMessage()
    {
    }

    public DareRewardConsumeValidationMessage(double dareId, uint type)
    {
      this.dareId = dareId;
      this.type = type;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element dareId.");
      writer.WriteDouble(this.dareId);
      writer.WriteByte((byte) this.type);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dareId = reader.ReadDouble();
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element of DareRewardConsumeValidationMessage.dareId.");
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of DareRewardConsumeValidationMessage.type.");
    }
  }
}
