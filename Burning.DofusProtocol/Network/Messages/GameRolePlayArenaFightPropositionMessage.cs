using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
  {
    public List<double> alliesId = new List<double>();
    public const uint Id = 6276;
    public uint fightId;
    public uint duration;

    public override uint MessageId
    {
      get
      {
        return 6276;
      }
    }

    public GameRolePlayArenaFightPropositionMessage()
    {
    }

    public GameRolePlayArenaFightPropositionMessage(
      uint fightId,
      List<double> alliesId,
      uint duration)
    {
      this.fightId = fightId;
      this.alliesId = alliesId;
      this.duration = duration;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteShort((short) this.alliesId.Count);
      for (int index = 0; index < this.alliesId.Count; ++index)
      {
        if (this.alliesId[index] < -9.00719925474099E+15 || this.alliesId[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.alliesId[index] + ") on element 2 (starting at 1) of alliesId.");
        writer.WriteDouble(this.alliesId[index]);
      }
      if (this.duration < 0U)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element duration.");
      writer.WriteVarShort((short) this.duration);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayArenaFightPropositionMessage.fightId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = reader.ReadDouble();
        if (num2 < -9.00719925474099E+15 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of alliesId.");
        this.alliesId.Add(num2);
      }
      this.duration = (uint) reader.ReadVarUhShort();
      if (this.duration < 0U)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element of GameRolePlayArenaFightPropositionMessage.duration.");
    }
  }
}
