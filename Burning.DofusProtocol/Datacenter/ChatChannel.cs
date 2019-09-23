using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ChatChannels", true)]
  public class ChatChannel : IDataObject
  {
    public const string MODULE = "ChatChannels";
    public uint Id;
    public uint NameId;
    public uint DescriptionId;
    public string Shortcut;
    public string ShortcutKey;
    public bool IsPrivate;
    public bool AllowObjects;
  }
}
