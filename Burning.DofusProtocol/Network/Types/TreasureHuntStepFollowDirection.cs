using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TreasureHuntStepFollowDirection : TreasureHuntStep
  {
    public new const uint Id = 468;
    public uint direction;
    public uint mapCount;

    public override uint TypeId
    {
      get
      {
        return 468;
      }
    }

    public TreasureHuntStepFollowDirection()
    {
    }

    public TreasureHuntStepFollowDirection(uint direction, uint mapCount)
    {
      this.direction = direction;
      this.mapCount = mapCount;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.direction);
      if (this.mapCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.mapCount + ") on element mapCount.");
      writer.WriteVarShort((short) this.mapCount);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.direction = (uint) reader.ReadByte();
      if (this.direction < 0U)
        throw new Exception("Forbidden value (" + (object) this.direction + ") on element of TreasureHuntStepFollowDirection.direction.");
      this.mapCount = (uint) reader.ReadVarUhShort();
      if (this.mapCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.mapCount + ") on element of TreasureHuntStepFollowDirection.mapCount.");
    }
  }
}
