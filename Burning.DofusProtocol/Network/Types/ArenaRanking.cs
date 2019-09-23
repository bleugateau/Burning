using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ArenaRanking
  {
    public const uint Id = 554;
    public uint rank;
    public uint bestRank;

    public virtual uint TypeId
    {
      get
      {
        return 554;
      }
    }

    public ArenaRanking()
    {
    }

    public ArenaRanking(uint rank, uint bestRank)
    {
      this.rank = rank;
      this.bestRank = bestRank;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.rank < 0U || this.rank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element rank.");
      writer.WriteVarShort((short) this.rank);
      if (this.bestRank < 0U || this.bestRank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.bestRank + ") on element bestRank.");
      writer.WriteVarShort((short) this.bestRank);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.rank = (uint) reader.ReadVarUhShort();
      if (this.rank < 0U || this.rank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element of ArenaRanking.rank.");
      this.bestRank = (uint) reader.ReadVarUhShort();
      if (this.bestRank < 0U || this.bestRank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.bestRank + ") on element of ArenaRanking.bestRank.");
    }
  }
}
