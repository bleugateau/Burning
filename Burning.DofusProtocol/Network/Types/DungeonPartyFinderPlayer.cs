using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class DungeonPartyFinderPlayer
  {
    public const uint Id = 373;
    public double playerId;
    public string playerName;
    public int breed;
    public bool sex;
    public uint level;

    public virtual uint TypeId
    {
      get
      {
        return 373;
      }
    }

    public DungeonPartyFinderPlayer()
    {
    }

    public DungeonPartyFinderPlayer(
      double playerId,
      string playerName,
      int breed,
      bool sex,
      uint level)
    {
      this.playerId = playerId;
      this.playerName = playerName;
      this.breed = breed;
      this.sex = sex;
      this.level = level;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of DungeonPartyFinderPlayer.playerId.");
      this.playerName = reader.ReadUTF();
      this.breed = (int) reader.ReadByte();
      if (this.breed < 1 || this.breed > 18)
        throw new Exception("Forbidden value (" + (object) this.breed + ") on element of DungeonPartyFinderPlayer.breed.");
      this.sex = reader.ReadBoolean();
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of DungeonPartyFinderPlayer.level.");
    }
  }
}
