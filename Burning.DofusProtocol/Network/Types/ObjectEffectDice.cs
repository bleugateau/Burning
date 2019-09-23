using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectDice : ObjectEffect
  {
    public new const uint Id = 73;
    public uint diceNum;
    public uint diceSide;
    public uint diceConst;

    public override uint TypeId
    {
      get
      {
        return 73;
      }
    }

    public ObjectEffectDice()
    {
    }

    public ObjectEffectDice(uint actionId, uint diceNum, uint diceSide, uint diceConst)
      : base(actionId)
    {
      this.diceNum = diceNum;
      this.diceSide = diceSide;
      this.diceConst = diceConst;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.diceNum < 0U)
        throw new Exception("Forbidden value (" + (object) this.diceNum + ") on element diceNum.");
      writer.WriteVarInt((int) this.diceNum);
      if (this.diceSide < 0U)
        throw new Exception("Forbidden value (" + (object) this.diceSide + ") on element diceSide.");
      writer.WriteVarInt((int) this.diceSide);
      if (this.diceConst < 0U)
        throw new Exception("Forbidden value (" + (object) this.diceConst + ") on element diceConst.");
      writer.WriteVarInt((int) this.diceConst);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.diceNum = reader.ReadVarUhInt();
      if (this.diceNum < 0U)
        throw new Exception("Forbidden value (" + (object) this.diceNum + ") on element of ObjectEffectDice.diceNum.");
      this.diceSide = reader.ReadVarUhInt();
      if (this.diceSide < 0U)
        throw new Exception("Forbidden value (" + (object) this.diceSide + ") on element of ObjectEffectDice.diceSide.");
      this.diceConst = reader.ReadVarUhInt();
      if (this.diceConst < 0U)
        throw new Exception("Forbidden value (" + (object) this.diceConst + ") on element of ObjectEffectDice.diceConst.");
    }
  }
}
