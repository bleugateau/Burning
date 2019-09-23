using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
  {
    public new const uint Id = 163;
    public EntityLook entityLook;
    public int breed;

    public override uint TypeId
    {
      get
      {
        return 163;
      }
    }

    public CharacterMinimalPlusLookInformations()
    {
    }

    public CharacterMinimalPlusLookInformations(
      double id,
      string name,
      uint level,
      EntityLook entityLook,
      int breed)
      : base(id, name, level)
    {
      this.entityLook = entityLook;
      this.breed = breed;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.entityLook.Serialize(writer);
      writer.WriteByte((byte) this.breed);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.entityLook = new EntityLook();
      this.entityLook.Deserialize(reader);
      this.breed = (int) reader.ReadByte();
    }
  }
}
