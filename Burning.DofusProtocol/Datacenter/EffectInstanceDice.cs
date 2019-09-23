using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceDice", true)]
  public class EffectInstanceDice : EffectInstanceInteger
  {
    public uint DiceNum;
    public uint DiceSide;
  }
}
