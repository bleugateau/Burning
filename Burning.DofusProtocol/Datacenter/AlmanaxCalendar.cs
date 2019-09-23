using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlmanaxCalendars", true)]
  public class AlmanaxCalendar : IDataObject
  {
    public const string MODULE = "AlmanaxCalendars";
    public int Id;
    public uint NameId;
    public uint DescId;
    public int NpcId;
    public List<int> BonusesIds;
  }
}
