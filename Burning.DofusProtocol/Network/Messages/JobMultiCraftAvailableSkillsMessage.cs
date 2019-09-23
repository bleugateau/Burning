using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
  {
    public List<uint> skills = new List<uint>();
    public new const uint Id = 5747;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 5747;
      }
    }

    public JobMultiCraftAvailableSkillsMessage()
    {
    }

    public JobMultiCraftAvailableSkillsMessage(bool enabled, double playerId, List<uint> skills)
      : base(enabled)
    {
      this.playerId = playerId;
      this.skills = skills;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteShort((short) this.skills.Count);
      for (int index = 0; index < this.skills.Count; ++index)
      {
        if (this.skills[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.skills[index] + ") on element 2 (starting at 1) of skills.");
        writer.WriteVarShort((short) this.skills[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of JobMultiCraftAvailableSkillsMessage.playerId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of skills.");
        this.skills.Add(num2);
      }
    }
  }
}
