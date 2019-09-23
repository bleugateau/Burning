using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterBaseCharacteristic
  {
    public const uint Id = 4;
    public int @base;
    public int additionnal;
    public int objectsAndMountBonus;
    public int alignGiftBonus;
    public int contextModif;

    public int Total_WithoutContext
    {
      get
      {
        return this.additionnal + this.objectsAndMountBonus + this.alignGiftBonus + this.@base;
      }
    }

    public int Total
    {
      get
      {
        return this.additionnal + this.objectsAndMountBonus + this.alignGiftBonus + this.@base + this.contextModif;
      }
    }

    public virtual uint TypeId
    {
      get
      {
        return 4;
      }
    }

    public CharacterBaseCharacteristic()
    {
    }

    public CharacterBaseCharacteristic(
      int @base,
      int additionnal,
      int objectsAndMountBonus,
      int alignGiftBonus,
      int contextModif)
    {
      this.@base = @base;
      this.additionnal = additionnal;
      this.objectsAndMountBonus = objectsAndMountBonus;
      this.alignGiftBonus = alignGiftBonus;
      this.contextModif = contextModif;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteVarShort((short) this.@base);
      writer.WriteVarShort((short) this.additionnal);
      writer.WriteVarShort((short) this.objectsAndMountBonus);
      writer.WriteVarShort((short) this.alignGiftBonus);
      writer.WriteVarShort((short) this.contextModif);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.@base = (int) reader.ReadVarShort();
      this.additionnal = (int) reader.ReadVarShort();
      this.objectsAndMountBonus = (int) reader.ReadVarShort();
      this.alignGiftBonus = (int) reader.ReadVarShort();
      this.contextModif = (int) reader.ReadVarShort();
    }
  }
}
