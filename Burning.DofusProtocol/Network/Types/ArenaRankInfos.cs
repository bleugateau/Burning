using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ArenaRankInfos
  {
    public const uint Id = 499;
    public ArenaRanking ranking;
    public ArenaLeagueRanking leagueRanking;
    public uint victoryCount;
    public uint fightcount;
    public uint numFightNeededForLadder;

    public virtual uint TypeId
    {
      get
      {
        return 499;
      }
    }

    public ArenaRankInfos()
    {
    }

    public ArenaRankInfos(
      ArenaRanking ranking,
      ArenaLeagueRanking leagueRanking,
      uint victoryCount,
      uint fightcount,
      uint numFightNeededForLadder)
    {
      this.ranking = ranking;
      this.leagueRanking = leagueRanking;
      this.victoryCount = victoryCount;
      this.fightcount = fightcount;
      this.numFightNeededForLadder = numFightNeededForLadder;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.ranking == null)
      {
        writer.WriteByte((byte) 0);
      }
      else
      {
        writer.WriteByte((byte) 1);
        this.ranking.Serialize(writer);
      }
      if (this.leagueRanking == null)
      {
        writer.WriteByte((byte) 0);
      }
      else
      {
        writer.WriteByte((byte) 1);
        this.leagueRanking.Serialize(writer);
      }
      if (this.victoryCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.victoryCount + ") on element victoryCount.");
      writer.WriteVarShort((short) this.victoryCount);
      if (this.fightcount < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightcount + ") on element fightcount.");
      writer.WriteVarShort((short) this.fightcount);
      if (this.numFightNeededForLadder < 0U)
        throw new Exception("Forbidden value (" + (object) this.numFightNeededForLadder + ") on element numFightNeededForLadder.");
      writer.WriteShort((short) this.numFightNeededForLadder);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      if (reader.ReadByte() == (byte) 0)
      {
        this.ranking = (ArenaRanking) null;
      }
      else
      {
        this.ranking = new ArenaRanking();
        this.ranking.Deserialize(reader);
      }
      if (reader.ReadByte() == (byte) 0)
      {
        this.leagueRanking = (ArenaLeagueRanking) null;
      }
      else
      {
        this.leagueRanking = new ArenaLeagueRanking();
        this.leagueRanking.Deserialize(reader);
      }
      this.victoryCount = (uint) reader.ReadVarUhShort();
      if (this.victoryCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.victoryCount + ") on element of ArenaRankInfos.victoryCount.");
      this.fightcount = (uint) reader.ReadVarUhShort();
      if (this.fightcount < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightcount + ") on element of ArenaRankInfos.fightcount.");
      this.numFightNeededForLadder = (uint) reader.ReadShort();
      if (this.numFightNeededForLadder < 0U)
        throw new Exception("Forbidden value (" + (object) this.numFightNeededForLadder + ") on element of ArenaRankInfos.numFightNeededForLadder.");
    }
  }
}
