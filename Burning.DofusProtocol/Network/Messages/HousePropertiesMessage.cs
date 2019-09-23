using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HousePropertiesMessage : NetworkMessage
  {
    public List<uint> doorsOnMap = new List<uint>();
    public const uint Id = 5734;
    public uint houseId;
    public HouseInstanceInformations properties;

    public override uint MessageId
    {
      get
      {
        return 5734;
      }
    }

    public HousePropertiesMessage()
    {
    }

    public HousePropertiesMessage(
      uint houseId,
      List<uint> doorsOnMap,
      HouseInstanceInformations properties)
    {
      this.houseId = houseId;
      this.doorsOnMap = doorsOnMap;
      this.properties = properties;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      writer.WriteShort((short) this.doorsOnMap.Count);
      for (int index = 0; index < this.doorsOnMap.Count; ++index)
      {
        if (this.doorsOnMap[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.doorsOnMap[index] + ") on element 2 (starting at 1) of doorsOnMap.");
        writer.WriteInt((int) this.doorsOnMap[index]);
      }
      writer.WriteShort((short) this.properties.TypeId);
      this.properties.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HousePropertiesMessage.houseId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of doorsOnMap.");
        this.doorsOnMap.Add(num2);
      }
      this.properties = ProtocolTypeManager.GetInstance<HouseInstanceInformations>((uint) reader.ReadUShort());
      this.properties.Deserialize(reader);
    }
  }
}
