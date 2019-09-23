namespace Burning.DofusProtocol.Data.D2P.Utils
{
  public class ColorMultiplicator
  {
    public bool IsOne;

    public int Red { get; set; }

    public int Green { get; set; }

    public int Blue { get; set; }

    public ColorMultiplicator(int param1, int param2, int param3, bool param4 = false)
    {
      this.Red = param1;
      this.Green = param2;
      this.Blue = param3;
      if (param4 || param1 + param2 + param3 != 0)
        return;
      this.IsOne = true;
    }

    public static int Clamp(int param1, int param2, int param3)
    {
      if (param1 > param3)
        return param3;
      if (param1 >= param2)
        return param1;
      return param2;
    }

    public ColorMultiplicator Multiply(ColorMultiplicator param1)
    {
      if (this.IsOne)
        return param1;
      if (param1.IsOne)
        return this;
      ColorMultiplicator colorMultiplicator = new ColorMultiplicator(0, 0, 0, false) { Red = this.Red + param1.Red, Green = this.Green + param1.Green, Blue = this.Blue + param1.Blue };
      colorMultiplicator.Red = ColorMultiplicator.Clamp(colorMultiplicator.Red, (int) sbyte.MinValue, (int) sbyte.MaxValue);
      colorMultiplicator.Green = ColorMultiplicator.Clamp(colorMultiplicator.Green, (int) sbyte.MinValue, (int) sbyte.MaxValue);
      colorMultiplicator.Blue = ColorMultiplicator.Clamp(colorMultiplicator.Blue, (int) sbyte.MinValue, (int) sbyte.MaxValue);
      colorMultiplicator.IsOne = false;
      return colorMultiplicator;
    }
  }
}
