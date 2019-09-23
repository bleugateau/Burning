using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutObjectItem : ShortcutObject
  {
    public new const uint Id = 371;
    public int itemUID;
    public int itemGID;

    public override uint TypeId
    {
      get
      {
        return 371;
      }
    }

    public ShortcutObjectItem()
    {
    }

    public ShortcutObjectItem(uint slot, int itemUID, int itemGID)
      : base(slot)
    {
      this.itemUID = itemUID;
      this.itemGID = itemGID;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.itemUID);
      writer.WriteInt(this.itemGID);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.itemUID = reader.ReadInt();
      this.itemGID = reader.ReadInt();
    }
  }
}
