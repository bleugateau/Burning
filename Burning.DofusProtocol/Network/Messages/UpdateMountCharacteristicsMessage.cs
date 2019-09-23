using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class UpdateMountCharacteristicsMessage : NetworkMessage
  {
    public List<UpdateMountCharacteristic> boostToUpdateList = new List<UpdateMountCharacteristic>();
    public const uint Id = 6753;
    public int rideId;

    public override uint MessageId
    {
      get
      {
        return 6753;
      }
    }

    public UpdateMountCharacteristicsMessage()
    {
    }

    public UpdateMountCharacteristicsMessage(
      int rideId,
      List<UpdateMountCharacteristic> boostToUpdateList)
    {
      this.rideId = rideId;
      this.boostToUpdateList = boostToUpdateList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteVarInt(this.rideId);
      writer.WriteShort((short) this.boostToUpdateList.Count);
      for (int index = 0; index < this.boostToUpdateList.Count; ++index)
      {
        writer.WriteShort((short) this.boostToUpdateList[index].TypeId);
        this.boostToUpdateList[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.rideId = reader.ReadVarInt();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        UpdateMountCharacteristic instance = ProtocolTypeManager.GetInstance<UpdateMountCharacteristic>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.boostToUpdateList.Add(instance);
      }
    }
  }
}
