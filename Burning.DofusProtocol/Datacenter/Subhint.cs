using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Subhints", true)]
  public class Subhint : IDataObject
  {
    public const string MODULE = "Subhints";
    public int Hintid;
    public string Hintparentuid;
    public string Hintanchoredelement;
    public int Hintanchor;
    public int Hintpositionx;
    public int Hintpositiony;
    public int Hintwidth;
    public int Hintheight;
    public string Hinthighlightedelement;
    public string Hinttexture;
    public int Hintorder;
    public string Hinttooltiptext;
    public int Hinttooltippositionenum;
    public string Hinttooltipurl;
    public int Hinttooltipoffsetx;
    public int Hinttooltipoffsety;
    public int Hinttooltipwidth;
    public double Hintcreationdate;
  }
}
