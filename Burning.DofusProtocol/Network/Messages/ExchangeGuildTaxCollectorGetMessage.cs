using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeGuildTaxCollectorGetMessage : NetworkMessage
  {
    public List<ObjectItemGenericQuantity> objectsInfos = new List<ObjectItemGenericQuantity>();
    public const uint Id = 5762;
    public string collectorName;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;
    public string userName;
    public double callerId;
    public string callerName;
    public double experience;
    public uint pods;

    public override uint MessageId
    {
      get
      {
        return 5762;
      }
    }

    public ExchangeGuildTaxCollectorGetMessage()
    {
    }

    public ExchangeGuildTaxCollectorGetMessage(
      string collectorName,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId,
      string userName,
      double callerId,
      string callerName,
      double experience,
      uint pods,
      List<ObjectItemGenericQuantity> objectsInfos)
    {
      this.collectorName = collectorName;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.userName = userName;
      this.callerId = callerId;
      this.callerName = callerName;
      this.experience = experience;
      this.pods = pods;
      this.objectsInfos = objectsInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.collectorName);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteUTF(this.userName);
      if (this.callerId < 0.0 || this.callerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.callerId + ") on element callerId.");
      writer.WriteVarLong((long) this.callerId);
      writer.WriteUTF(this.callerName);
      if (this.experience < -9.00719925474099E+15 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteDouble(this.experience);
      if (this.pods < 0U)
        throw new Exception("Forbidden value (" + (object) this.pods + ") on element pods.");
      writer.WriteVarShort((short) this.pods);
      writer.WriteShort((short) this.objectsInfos.Count);
      for (int index = 0; index < this.objectsInfos.Count; ++index)
        this.objectsInfos[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.collectorName = reader.ReadUTF();
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of ExchangeGuildTaxCollectorGetMessage.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of ExchangeGuildTaxCollectorGetMessage.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of ExchangeGuildTaxCollectorGetMessage.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of ExchangeGuildTaxCollectorGetMessage.subAreaId.");
      this.userName = reader.ReadUTF();
      this.callerId = (double) reader.ReadVarUhLong();
      if (this.callerId < 0.0 || this.callerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.callerId + ") on element of ExchangeGuildTaxCollectorGetMessage.callerId.");
      this.callerName = reader.ReadUTF();
      this.experience = reader.ReadDouble();
      if (this.experience < -9.00719925474099E+15 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of ExchangeGuildTaxCollectorGetMessage.experience.");
      this.pods = (uint) reader.ReadVarUhShort();
      if (this.pods < 0U)
        throw new Exception("Forbidden value (" + (object) this.pods + ") on element of ExchangeGuildTaxCollectorGetMessage.pods.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemGenericQuantity itemGenericQuantity = new ObjectItemGenericQuantity();
        itemGenericQuantity.Deserialize(reader);
        this.objectsInfos.Add(itemGenericQuantity);
      }
    }
  }
}
