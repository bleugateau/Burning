using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("FinishMoves", true)]
  public class FinishMove : IDataObject
  {
    public const string MODULE = "FinishMoves";
    public int Id;
    public int Duration;
    public bool Free;
    public uint NameId;
    public int Category;
    public int SpellLevel;
  }
}
