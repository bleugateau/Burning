using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public new const uint Id = 45;
        public bool sex;

        public override uint TypeId
        {
            get
            {
                return 45;
            }
        }

        public CharacterBaseInformations()
        {
        }

        public CharacterBaseInformations(
          double id,
          string name,
          uint level,
          EntityLook entityLook,
          int breed,
          bool sex)
          : base(id, name, level, entityLook, breed)
        {
            this.sex = sex;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(this.sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            this.sex = reader.ReadBoolean();
        }
    }
}
