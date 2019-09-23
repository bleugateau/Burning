using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class DareReward
  {
    public const uint Id = 505;
    public uint type;
    public uint monsterId;
    public double kamas;
    public double dareId;

    public virtual uint TypeId
    {
      get
      {
        return 505;
      }
    }

    public DareReward()
    {
    }

    public DareReward(uint type, uint monsterId, double kamas, double dareId)
    {
      this.type = type;
      this.monsterId = monsterId;
      this.kamas = kamas;
      this.dareId = dareId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
      if (this.monsterId < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterId + ") on element monsterId.");
      writer.WriteVarShort((short) this.monsterId);
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element kamas.");
      writer.WriteVarLong((long) this.kamas);
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element dareId.");
      writer.WriteDouble(this.dareId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of DareReward.type.");
      this.monsterId = (uint) reader.ReadVarUhShort();
      if (this.monsterId < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterId + ") on element of DareReward.monsterId.");
      this.kamas = (double) reader.ReadVarUhLong();
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element of DareReward.kamas.");
      this.dareId = reader.ReadDouble();
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element of DareReward.dareId.");
    }
  }
}
