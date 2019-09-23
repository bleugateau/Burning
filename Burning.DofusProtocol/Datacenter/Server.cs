using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Servers", true)]
  public class Server : IDataObject
  {
    public const string MODULE = "Servers";
    public int Id;
    public uint NameId;
    public uint CommentId;
    public double OpeningDate;
    public string Language;
    public int PopulationId;
    public uint GameTypeId;
    public int CommunityId;
    public List<string> RestrictedToLanguages;
    public bool MonoAccount;
  }
}
