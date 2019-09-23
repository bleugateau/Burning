using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SpellListMessage : NetworkMessage
  {
    public List<SpellItem> spells = new List<SpellItem>();
    public const uint Id = 1200;
    public bool spellPrevisualization;

    public override uint MessageId
    {
      get
      {
        return 1200;
      }
    }

    public SpellListMessage()
    {
    }

    public SpellListMessage(bool spellPrevisualization, List<SpellItem> spells)
    {
      this.spellPrevisualization = spellPrevisualization;
      this.spells = spells;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.spellPrevisualization);
      writer.WriteShort((short) this.spells.Count);
      for (int index = 0; index < this.spells.Count; ++index)
        this.spells[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellPrevisualization = reader.ReadBoolean();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        SpellItem spellItem = new SpellItem();
        spellItem.Deserialize(reader);
        this.spells.Add(spellItem);
      }
    }
  }
}
