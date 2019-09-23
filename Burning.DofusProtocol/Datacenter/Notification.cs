using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Notifications", true)]
  public class Notification : IDataObject
  {
    public const string MODULE = "Notifications";
    public int Id;
    public uint TitleId;
    public uint MessageId;
    public int IconId;
    public int TypeId;
    public string Trigger;
  }
}
