using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Playlists", true)]
  public class Playlist : IDataObject
  {
    public const int AMBIENTTYPEROLEPLAY = 1;
    public const int AMBIENTTYPEAMBIENT = 2;
    public const int AMBIENTTYPEFIGHT = 3;
    public const int AMBIENTTYPEBOSS = 4;
    public const string MODULE = "Playlists";
    public int Id;
    public int SilenceDuration;
    public int Iteration;
    public int Type;
    public List<PlaylistSound> Sounds;
  }
}
