using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ServerCommunities", true)]
  public class ServerCommunity : IDataObject
  {
    public const string MODULE = "ServerCommunities";
    public int Id;
    public uint NameId;
    public string ShortId;
    public List<string> DefaultCountries;
    public List<int> SupportedLangIds;
    public int NamingRulePlayerNameId;
    public int NamingRuleGuildNameId;
    public int NamingRuleAllianceNameId;
    public int NamingRuleAllianceTagId;
    public int NamingRulePartyNameId;
    public int NamingRuleMountNameId;
    public int NamingRuleNameGeneratorId;
    public int NamingRuleAdminId;
    public int NamingRuleModoId;
  }
}
