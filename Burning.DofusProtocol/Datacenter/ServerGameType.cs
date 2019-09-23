using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ServerGameTypes", true)]
  public class ServerGameType : IDataObject
  {
    public const string MODULE = "ServerGameTypes";
    public int Id;
    public bool SelectableByPlayer;
    public uint NameId;
    public uint RulesId;
    public uint DescriptionId;
  }
}
