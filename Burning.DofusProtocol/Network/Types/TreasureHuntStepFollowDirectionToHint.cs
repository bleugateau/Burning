using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TreasureHuntStepFollowDirectionToHint : TreasureHuntStep
  {
    public new const uint Id = 472;
    public uint direction;
    public uint npcId;

    public override uint TypeId
    {
      get
      {
        return 472;
      }
    }

    public TreasureHuntStepFollowDirectionToHint()
    {
    }

    public TreasureHuntStepFollowDirectionToHint(uint direction, uint npcId)
    {
      this.direction = direction;
      this.npcId = npcId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.direction);
      if (this.npcId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element npcId.");
      writer.WriteVarShort((short) this.npcId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.direction = (uint) reader.ReadByte();
      if (this.direction < 0U)
        throw new Exception("Forbidden value (" + (object) this.direction + ") on element of TreasureHuntStepFollowDirectionToHint.direction.");
      this.npcId = (uint) reader.ReadVarUhShort();
      if (this.npcId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element of TreasureHuntStepFollowDirectionToHint.npcId.");
    }
  }
}
