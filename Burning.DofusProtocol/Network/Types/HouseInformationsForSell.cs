using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class HouseInformationsForSell
  {
    public List<int> skillListIds = new List<int>();
    public const uint Id = 221;
    public uint instanceId;
    public bool secondHand;
    public uint modelId;
    public string ownerName;
    public bool ownerConnected;
    public int worldX;
    public int worldY;
    public uint subAreaId;
    public int nbRoom;
    public int nbChest;
    public bool isLocked;
    public double price;

    public virtual uint TypeId
    {
      get
      {
        return 221;
      }
    }

    public HouseInformationsForSell()
    {
    }

    public HouseInformationsForSell(
      uint instanceId,
      bool secondHand,
      uint modelId,
      string ownerName,
      bool ownerConnected,
      int worldX,
      int worldY,
      uint subAreaId,
      int nbRoom,
      int nbChest,
      List<int> skillListIds,
      bool isLocked,
      double price)
    {
      this.instanceId = instanceId;
      this.secondHand = secondHand;
      this.modelId = modelId;
      this.ownerName = ownerName;
      this.ownerConnected = ownerConnected;
      this.worldX = worldX;
      this.worldY = worldY;
      this.subAreaId = subAreaId;
      this.nbRoom = nbRoom;
      this.nbChest = nbChest;
      this.skillListIds = skillListIds;
      this.isLocked = isLocked;
      this.price = price;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      writer.WriteBoolean(this.secondHand);
      if (this.modelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.modelId + ") on element modelId.");
      writer.WriteVarInt((int) this.modelId);
      writer.WriteUTF(this.ownerName);
      writer.WriteBoolean(this.ownerConnected);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteByte((byte) this.nbRoom);
      writer.WriteByte((byte) this.nbChest);
      writer.WriteShort((short) this.skillListIds.Count);
      for (int index = 0; index < this.skillListIds.Count; ++index)
        writer.WriteInt(this.skillListIds[index]);
      writer.WriteBoolean(this.isLocked);
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseInformationsForSell.instanceId.");
      this.secondHand = reader.ReadBoolean();
      this.modelId = reader.ReadVarUhInt();
      if (this.modelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.modelId + ") on element of HouseInformationsForSell.modelId.");
      this.ownerName = reader.ReadUTF();
      this.ownerConnected = reader.ReadBoolean();
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of HouseInformationsForSell.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of HouseInformationsForSell.worldY.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of HouseInformationsForSell.subAreaId.");
      this.nbRoom = (int) reader.ReadByte();
      this.nbChest = (int) reader.ReadByte();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.skillListIds.Add(reader.ReadInt());
      this.isLocked = reader.ReadBoolean();
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of HouseInformationsForSell.price.");
    }
  }
}
