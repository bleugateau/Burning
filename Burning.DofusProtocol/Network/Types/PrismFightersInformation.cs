using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PrismFightersInformation
  {
    public List<CharacterMinimalPlusLookInformations> allyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
    public List<CharacterMinimalPlusLookInformations> enemyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
    public const uint Id = 443;
    public uint subAreaId;
    public ProtectedEntityWaitingForHelpInfo waitingForHelpInfo;

    public virtual uint TypeId
    {
      get
      {
        return 443;
      }
    }

    public PrismFightersInformation()
    {
    }

    public PrismFightersInformation(
      uint subAreaId,
      ProtectedEntityWaitingForHelpInfo waitingForHelpInfo,
      List<CharacterMinimalPlusLookInformations> allyCharactersInformations,
      List<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
    {
      this.subAreaId = subAreaId;
      this.waitingForHelpInfo = waitingForHelpInfo;
      this.allyCharactersInformations = allyCharactersInformations;
      this.enemyCharactersInformations = enemyCharactersInformations;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      this.waitingForHelpInfo.Serialize(writer);
      writer.WriteShort((short) this.allyCharactersInformations.Count);
      for (int index = 0; index < this.allyCharactersInformations.Count; ++index)
      {
        writer.WriteShort((short) this.allyCharactersInformations[index].TypeId);
        this.allyCharactersInformations[index].Serialize(writer);
      }
      writer.WriteShort((short) this.enemyCharactersInformations.Count);
      for (int index = 0; index < this.enemyCharactersInformations.Count; ++index)
      {
        writer.WriteShort((short) this.enemyCharactersInformations[index].TypeId);
        this.enemyCharactersInformations[index].Serialize(writer);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismFightersInformation.subAreaId.");
      this.waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
      this.waitingForHelpInfo.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        CharacterMinimalPlusLookInformations instance = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.allyCharactersInformations.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        CharacterMinimalPlusLookInformations instance = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.enemyCharactersInformations.Add(instance);
      }
    }
  }
}
