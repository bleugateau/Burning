using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class MonsterInGroupInformations : MonsterInGroupLightInformations
  {
    public new const uint Id = 144;
    public EntityLook look;

    public override uint TypeId
    {
      get
      {
        return 144;
      }
    }

    public MonsterInGroupInformations()
    {
    }

    public MonsterInGroupInformations(int genericId, uint grade, uint level, EntityLook look)
      : base(genericId, grade, level)
    {
      this.look = look;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.look = new EntityLook();
      this.look.Deserialize(reader);
    }
  }
}
