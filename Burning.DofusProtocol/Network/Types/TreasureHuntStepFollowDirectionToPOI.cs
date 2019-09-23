using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep
  {
    public new const uint Id = 461;
    public uint direction;
    public uint poiLabelId;

    public override uint TypeId
    {
      get
      {
        return 461;
      }
    }

    public TreasureHuntStepFollowDirectionToPOI()
    {
    }

    public TreasureHuntStepFollowDirectionToPOI(uint direction, uint poiLabelId)
    {
      this.direction = direction;
      this.poiLabelId = poiLabelId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.direction);
      if (this.poiLabelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.poiLabelId + ") on element poiLabelId.");
      writer.WriteVarShort((short) this.poiLabelId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.direction = (uint) reader.ReadByte();
      if (this.direction < 0U)
        throw new Exception("Forbidden value (" + (object) this.direction + ") on element of TreasureHuntStepFollowDirectionToPOI.direction.");
      this.poiLabelId = (uint) reader.ReadVarUhShort();
      if (this.poiLabelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.poiLabelId + ") on element of TreasureHuntStepFollowDirectionToPOI.poiLabelId.");
    }
  }
}
