using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Npcs", true)]
  public class Npc : IDataObject
  {
    public const string MODULE = "Npcs";
    public int Id;
    public uint NameId;
    public List<List<int>> DialogMessages;
    public List<List<int>> DialogReplies;
    public List<uint> Actions;
    public uint Gender;
    public string Look;
    public int TokenShop;
    public List<AnimFunNpcData> AnimFunList;
    public bool FastAnimsFun;
  }
}
