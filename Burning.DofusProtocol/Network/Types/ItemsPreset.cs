using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ItemsPreset : Preset
  {
    public List<ItemForPreset> items = new List<ItemForPreset>();
    public new const uint Id = 517;
    public bool mountEquipped;
    public EntityLook look;

    public override uint TypeId
    {
      get
      {
        return 517;
      }
    }

    public ItemsPreset()
    {
    }

    public ItemsPreset(int id, List<ItemForPreset> items, bool mountEquipped, EntityLook look)
      : base(id)
    {
      this.items = items;
      this.mountEquipped = mountEquipped;
      this.look = look;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.items.Count);
      for (int index = 0; index < this.items.Count; ++index)
        this.items[index].Serialize(writer);
      writer.WriteBoolean(this.mountEquipped);
      this.look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ItemForPreset itemForPreset = new ItemForPreset();
        itemForPreset.Deserialize(reader);
        this.items.Add(itemForPreset);
      }
      this.mountEquipped = reader.ReadBoolean();
      this.look = new EntityLook();
      this.look.Deserialize(reader);
    }
  }
}
