using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SlaveSwitchContextMessage : NetworkMessage
  {
    public List<SpellItem> slaveSpells = new List<SpellItem>();
    public List<Shortcut> shortcuts = new List<Shortcut>();
    public const uint Id = 6214;
    public double masterId;
    public double slaveId;
    public CharacterCharacteristicsInformations slaveStats;

    public override uint MessageId
    {
      get
      {
        return 6214;
      }
    }

    public SlaveSwitchContextMessage()
    {
    }

    public SlaveSwitchContextMessage(
      double masterId,
      double slaveId,
      List<SpellItem> slaveSpells,
      CharacterCharacteristicsInformations slaveStats,
      List<Shortcut> shortcuts)
    {
      this.masterId = masterId;
      this.slaveId = slaveId;
      this.slaveSpells = slaveSpells;
      this.slaveStats = slaveStats;
      this.shortcuts = shortcuts;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element masterId.");
      writer.WriteDouble(this.masterId);
      if (this.slaveId < -9.00719925474099E+15 || this.slaveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.slaveId + ") on element slaveId.");
      writer.WriteDouble(this.slaveId);
      writer.WriteShort((short) this.slaveSpells.Count);
      for (int index = 0; index < this.slaveSpells.Count; ++index)
        this.slaveSpells[index].Serialize(writer);
      this.slaveStats.Serialize(writer);
      writer.WriteShort((short) this.shortcuts.Count);
      for (int index = 0; index < this.shortcuts.Count; ++index)
      {
        writer.WriteShort((short) this.shortcuts[index].TypeId);
        this.shortcuts[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.masterId = reader.ReadDouble();
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element of SlaveSwitchContextMessage.masterId.");
      this.slaveId = reader.ReadDouble();
      if (this.slaveId < -9.00719925474099E+15 || this.slaveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.slaveId + ") on element of SlaveSwitchContextMessage.slaveId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        SpellItem spellItem = new SpellItem();
        spellItem.Deserialize(reader);
        this.slaveSpells.Add(spellItem);
      }
      this.slaveStats = new CharacterCharacteristicsInformations();
      this.slaveStats.Deserialize(reader);
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        Shortcut instance = ProtocolTypeManager.GetInstance<Shortcut>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.shortcuts.Add(instance);
      }
    }
  }
}
