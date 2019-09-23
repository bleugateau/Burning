using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class HouseOnMapInformations : HouseInformations
  {
    public List<uint> doorsOnMap = new List<uint>();
    public List<HouseInstanceInformations> houseInstances = new List<HouseInstanceInformations>();
    public new const uint Id = 510;

    public override uint TypeId
    {
      get
      {
        return 510;
      }
    }

    public HouseOnMapInformations()
    {
    }

    public HouseOnMapInformations(
      uint houseId,
      uint modelId,
      List<uint> doorsOnMap,
      List<HouseInstanceInformations> houseInstances)
      : base(houseId, modelId)
    {
      this.doorsOnMap = doorsOnMap;
      this.houseInstances = houseInstances;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.doorsOnMap.Count);
      for (int index = 0; index < this.doorsOnMap.Count; ++index)
      {
        if (this.doorsOnMap[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.doorsOnMap[index] + ") on element 1 (starting at 1) of doorsOnMap.");
        writer.WriteInt((int) this.doorsOnMap[index]);
      }
      writer.WriteShort((short) this.houseInstances.Count);
      for (int index = 0; index < this.houseInstances.Count; ++index)
        this.houseInstances[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of doorsOnMap.");
        this.doorsOnMap.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        HouseInstanceInformations instanceInformations = new HouseInstanceInformations();
        instanceInformations.Deserialize(reader);
        this.houseInstances.Add(instanceInformations);
      }
    }
  }
}
