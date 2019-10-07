using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
    public class SpellItem : Item
    {
        public new const uint Id = 49;
        public int spellId;
        public int spellLevel;

        public override uint TypeId
        {
            get
            {
                return 49;
            }
        }

        public SpellItem()
        {
        }

        public SpellItem(int spellId, int spellLevel)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(this.spellId);
            if (this.spellLevel < 1 || this.spellLevel > 200)
                throw new Exception("Forbidden value (" + (object)this.spellLevel + ") on element spellLevel.");
            writer.WriteShort((short)this.spellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            this.spellId = reader.ReadInt();
            this.spellLevel = (int)reader.ReadShort();
            if (this.spellLevel < 1 || this.spellLevel > 200)
                throw new Exception("Forbidden value (" + (object)this.spellLevel + ") on element of SpellItem.spellLevel.");
        }
    }
}
