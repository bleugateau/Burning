using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionObjectUse : HumanOption
  {
    public new const uint Id = 449;
    public uint delayTypeId;
    public double delayEndTime;
    public uint objectGID;

    public override uint TypeId
    {
      get
      {
        return 449;
      }
    }

    public HumanOptionObjectUse()
    {
    }

    public HumanOptionObjectUse(uint delayTypeId, double delayEndTime, uint objectGID)
    {
      this.delayTypeId = delayTypeId;
      this.delayEndTime = delayEndTime;
      this.objectGID = objectGID;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.delayTypeId);
      if (this.delayEndTime < 0.0 || this.delayEndTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayEndTime + ") on element delayEndTime.");
      writer.WriteDouble(this.delayEndTime);
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.delayTypeId = (uint) reader.ReadByte();
      if (this.delayTypeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.delayTypeId + ") on element of HumanOptionObjectUse.delayTypeId.");
      this.delayEndTime = reader.ReadDouble();
      if (this.delayEndTime < 0.0 || this.delayEndTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayEndTime + ") on element of HumanOptionObjectUse.delayEndTime.");
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of HumanOptionObjectUse.objectGID.");
    }
  }
}
