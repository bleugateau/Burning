using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChallengeTargetsListMessage : NetworkMessage
  {
    public List<double> targetIds = new List<double>();
    public List<int> targetCells = new List<int>();
    public const uint Id = 5613;

    public override uint MessageId
    {
      get
      {
        return 5613;
      }
    }

    public ChallengeTargetsListMessage()
    {
    }

    public ChallengeTargetsListMessage(List<double> targetIds, List<int> targetCells)
    {
      this.targetIds = targetIds;
      this.targetCells = targetCells;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.targetIds.Count);
      for (int index = 0; index < this.targetIds.Count; ++index)
      {
        if (this.targetIds[index] < -9.00719925474099E+15 || this.targetIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.targetIds[index] + ") on element 1 (starting at 1) of targetIds.");
        writer.WriteDouble(this.targetIds[index]);
      }
      writer.WriteShort((short) this.targetCells.Count);
      for (int index = 0; index < this.targetCells.Count; ++index)
      {
        if (this.targetCells[index] < -1 || this.targetCells[index] > 559)
          throw new Exception("Forbidden value (" + (object) this.targetCells[index] + ") on element 2 (starting at 1) of targetCells.");
        writer.WriteShort((short) this.targetCells[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = reader.ReadDouble();
        if (num2 < -9.00719925474099E+15 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of targetIds.");
        this.targetIds.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        int num2 = (int) reader.ReadShort();
        if (num2 < -1 || num2 > 559)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of targetCells.");
        this.targetCells.Add(num2);
      }
    }
  }
}
