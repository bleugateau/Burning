using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ExternalNotifications", true)]
  public class ExternalNotification : IDataObject
  {
    public const string MODULE = "ExternalNotifications";
    public int Id;
    public int CategoryId;
    public int IconId;
    public int ColorId;
    public uint DescriptionId;
    public bool DefaultEnable;
    public bool DefaultSound;
    public bool DefaultNotify;
    public bool DefaultMultiAccount;
    public string Name;
    public uint MessageId;
  }
}
