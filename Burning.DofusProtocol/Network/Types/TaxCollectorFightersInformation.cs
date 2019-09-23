using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorFightersInformation
  {
    public List<CharacterMinimalPlusLookInformations> allyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
    public List<CharacterMinimalPlusLookInformations> enemyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
    public const uint Id = 169;
    public double collectorId;

    public virtual uint TypeId
    {
      get
      {
        return 169;
      }
    }

    public TaxCollectorFightersInformation()
    {
    }

    public TaxCollectorFightersInformation(
      double collectorId,
      List<CharacterMinimalPlusLookInformations> allyCharactersInformations,
      List<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
    {
      this.collectorId = collectorId;
      this.allyCharactersInformations = allyCharactersInformations;
      this.enemyCharactersInformations = enemyCharactersInformations;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.collectorId < 0.0 || this.collectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.collectorId + ") on element collectorId.");
      writer.WriteDouble(this.collectorId);
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
      this.collectorId = reader.ReadDouble();
      if (this.collectorId < 0.0 || this.collectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.collectorId + ") on element of TaxCollectorFightersInformation.collectorId.");
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
