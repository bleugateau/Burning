using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SoundAnimations", true)]
  public class SoundAnimation : IDataObject
  {
    public string MODULE = "SoundAnimations";
    public uint Id;
    public string Name;
    public string Label;
    public string Filename;
    public int Volume;
    public int Rolloff;
    public int AutomationDuration;
    public int AutomationVolume;
    public int AutomationFadeIn;
    public int AutomationFadeOut;
    public bool NoCutSilence;
    public uint StartFrame;
  }
}
