using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutObject : Shortcut
  {
    public new const uint Id = 367;

    public override uint TypeId
    {
      get
      {
        return 367;
      }
    }

    public ShortcutObject()
    {
    }

    public ShortcutObject(uint slot)
      : base(slot)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
