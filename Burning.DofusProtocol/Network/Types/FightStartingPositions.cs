using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightStartingPositions
  {
    public List<uint> positionsForChallengers = new List<uint>();
    public List<uint> positionsForDefenders = new List<uint>();
    public const uint Id = 513;

    public virtual uint TypeId
    {
      get
      {
        return 513;
      }
    }

    public FightStartingPositions()
    {
    }

    public FightStartingPositions(
      List<uint> positionsForChallengers,
      List<uint> positionsForDefenders)
    {
      this.positionsForChallengers = positionsForChallengers;
      this.positionsForDefenders = positionsForDefenders;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.positionsForChallengers.Count);
      for (int index = 0; index < this.positionsForChallengers.Count; ++index)
      {
        if (this.positionsForChallengers[index] < 0U || this.positionsForChallengers[index] > 559U)
          throw new Exception("Forbidden value (" + (object) this.positionsForChallengers[index] + ") on element 1 (starting at 1) of positionsForChallengers.");
        writer.WriteVarShort((short) this.positionsForChallengers[index]);
      }
      writer.WriteShort((short) this.positionsForDefenders.Count);
      for (int index = 0; index < this.positionsForDefenders.Count; ++index)
      {
        if (this.positionsForDefenders[index] < 0U || this.positionsForDefenders[index] > 559U)
          throw new Exception("Forbidden value (" + (object) this.positionsForDefenders[index] + ") on element 2 (starting at 1) of positionsForDefenders.");
        writer.WriteVarShort((short) this.positionsForDefenders[index]);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U || num2 > 559U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of positionsForChallengers.");
        this.positionsForChallengers.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U || num2 > 559U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of positionsForDefenders.");
        this.positionsForDefenders.Add(num2);
      }
    }
  }
}
