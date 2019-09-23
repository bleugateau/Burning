using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionSkillUse : HumanOption
  {
    public new const uint Id = 495;
    public uint elementId;
    public uint skillId;
    public double skillEndTime;

    public override uint TypeId
    {
      get
      {
        return 495;
      }
    }

    public HumanOptionSkillUse()
    {
    }

    public HumanOptionSkillUse(uint elementId, uint skillId, double skillEndTime)
    {
      this.elementId = elementId;
      this.skillId = skillId;
      this.skillEndTime = skillEndTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element elementId.");
      writer.WriteVarInt((int) this.elementId);
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarShort((short) this.skillId);
      if (this.skillEndTime < -9.00719925474099E+15 || this.skillEndTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.skillEndTime + ") on element skillEndTime.");
      writer.WriteDouble(this.skillEndTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.elementId = reader.ReadVarUhInt();
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element of HumanOptionSkillUse.elementId.");
      this.skillId = (uint) reader.ReadVarUhShort();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of HumanOptionSkillUse.skillId.");
      this.skillEndTime = reader.ReadDouble();
      if (this.skillEndTime < -9.00719925474099E+15 || this.skillEndTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.skillEndTime + ") on element of HumanOptionSkillUse.skillEndTime.");
    }
  }
}
