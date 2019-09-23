using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ItemDurability
  {
    public const uint Id = 168;
    public int durability;
    public int durabilityMax;

    public virtual uint TypeId
    {
      get
      {
        return 168;
      }
    }

    public ItemDurability()
    {
    }

    public ItemDurability(int durability, int durabilityMax)
    {
      this.durability = durability;
      this.durabilityMax = durabilityMax;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.durability);
      writer.WriteShort((short) this.durabilityMax);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.durability = (int) reader.ReadShort();
      this.durabilityMax = (int) reader.ReadShort();
    }
  }
}
