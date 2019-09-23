using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class PaddockItem : ObjectItemInRolePlay
  {
    public new const uint Id = 185;
    public ItemDurability durability;

    public override uint TypeId
    {
      get
      {
        return 185;
      }
    }

    public PaddockItem()
    {
    }

    public PaddockItem(uint cellId, uint objectGID, ItemDurability durability)
      : base(cellId, objectGID)
    {
      this.durability = durability;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.durability.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.durability = new ItemDurability();
      this.durability.Deserialize(reader);
    }
  }
}
