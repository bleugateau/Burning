using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ArenaLeagueRanking
  {
    public const uint Id = 553;
    public uint rank;
    public uint leagueId;
    public int leaguePoints;
    public int totalLeaguePoints;
    public int ladderPosition;

    public virtual uint TypeId
    {
      get
      {
        return 553;
      }
    }

    public ArenaLeagueRanking()
    {
    }

    public ArenaLeagueRanking(
      uint rank,
      uint leagueId,
      int leaguePoints,
      int totalLeaguePoints,
      int ladderPosition)
    {
      this.rank = rank;
      this.leagueId = leagueId;
      this.leaguePoints = leaguePoints;
      this.totalLeaguePoints = totalLeaguePoints;
      this.ladderPosition = ladderPosition;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.rank < 0U || this.rank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element rank.");
      writer.WriteVarShort((short) this.rank);
      if (this.leagueId < 0U)
        throw new Exception("Forbidden value (" + (object) this.leagueId + ") on element leagueId.");
      writer.WriteVarShort((short) this.leagueId);
      writer.WriteVarShort((short) this.leaguePoints);
      writer.WriteVarShort((short) this.totalLeaguePoints);
      writer.WriteInt(this.ladderPosition);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.rank = (uint) reader.ReadVarUhShort();
      if (this.rank < 0U || this.rank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element of ArenaLeagueRanking.rank.");
      this.leagueId = (uint) reader.ReadVarUhShort();
      if (this.leagueId < 0U)
        throw new Exception("Forbidden value (" + (object) this.leagueId + ") on element of ArenaLeagueRanking.leagueId.");
      this.leaguePoints = (int) reader.ReadVarShort();
      this.totalLeaguePoints = (int) reader.ReadVarShort();
      this.ladderPosition = reader.ReadInt();
    }
  }
}
