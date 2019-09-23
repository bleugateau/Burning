using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("PlaylistSounds", true)]
  public class PlaylistSound : IDataObject
  {
    public const string MODULE = "PlaylistSounds";
    public string Id;
    public int Volume;
    public int Channel;
  }
}
