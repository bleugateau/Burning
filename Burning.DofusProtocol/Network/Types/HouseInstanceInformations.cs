using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HouseInstanceInformations
  {
    public const uint Id = 511;
    public uint instanceId;
    public bool secondHand;
    public bool isLocked;
    public string ownerName;
    public double price;
    public bool isSaleLocked;

    public virtual uint TypeId
    {
      get
      {
        return 511;
      }
    }

    public HouseInstanceInformations()
    {
    }

    public HouseInstanceInformations(
      uint instanceId,
      bool secondHand,
      bool isLocked,
      string ownerName,
      double price,
      bool isSaleLocked)
    {
      this.instanceId = instanceId;
      this.secondHand = secondHand;
      this.isLocked = isLocked;
      this.ownerName = ownerName;
      this.price = price;
      this.isSaleLocked = isSaleLocked;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.secondHand), (byte) 1, this.isLocked), (byte) 2, this.isSaleLocked);
      writer.WriteByte((byte) num);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      writer.WriteUTF(this.ownerName);
      if (this.price < -9.00719925474099E+15 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.secondHand = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.isLocked = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.isSaleLocked = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 2);
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseInstanceInformations.instanceId.");
      this.ownerName = reader.ReadUTF();
      this.price = (double) reader.ReadVarLong();
      if (this.price < -9.00719925474099E+15 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of HouseInstanceInformations.price.");
    }
  }
}
