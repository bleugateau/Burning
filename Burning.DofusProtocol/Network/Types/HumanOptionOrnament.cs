using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionOrnament : HumanOption
  {
    public new const uint Id = 411;
    public uint ornamentId;
    public uint level;
    public int leagueId;
    public int ladderPosition;

    public override uint TypeId
    {
      get
      {
        return 411;
      }
    }

    public HumanOptionOrnament()
    {
    }

    public HumanOptionOrnament(uint ornamentId, uint level, int leagueId, int ladderPosition)
    {
      this.ornamentId = ornamentId;
      this.level = level;
      this.leagueId = leagueId;
      this.ladderPosition = ladderPosition;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.ornamentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ornamentId + ") on element ornamentId.");
      writer.WriteVarShort((short) this.ornamentId);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      writer.WriteVarShort((short) this.leagueId);
      writer.WriteInt(this.ladderPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.ornamentId = (uint) reader.ReadVarUhShort();
      if (this.ornamentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ornamentId + ") on element of HumanOptionOrnament.ornamentId.");
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of HumanOptionOrnament.level.");
      this.leagueId = (int) reader.ReadVarShort();
      this.ladderPosition = reader.ReadInt();
    }
  }
}
