using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AmbientSounds", true)]
  public class AmbientSound : PlaylistSound
  {
    public const int AMBIENTTYPEROLEPLAY = 1;
    public const int AMBIENTTYPEAMBIENT = 2;
    public const int AMBIENTTYPEFIGHT = 3;
    public const int AMBIENTTYPEBOSS = 4;
    public new const string MODULE = "AmbientSounds";
    public int CriterionId;
    public uint SilenceMin;
    public uint SilenceMax;
    public int Typeid;
  }
}
