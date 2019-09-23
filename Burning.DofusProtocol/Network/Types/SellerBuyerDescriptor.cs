using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class SellerBuyerDescriptor
  {
    public List<uint> quantities = new List<uint>();
    public List<uint> types = new List<uint>();
    public const uint Id = 121;
    public double taxPercentage;
    public double taxModificationPercentage;
    public uint maxItemLevel;
    public uint maxItemPerAccount;
    public int npcContextualId;
    public uint unsoldDelay;

    public virtual uint TypeId
    {
      get
      {
        return 121;
      }
    }

    public SellerBuyerDescriptor()
    {
    }

    public SellerBuyerDescriptor(
      List<uint> quantities,
      List<uint> types,
      double taxPercentage,
      double taxModificationPercentage,
      uint maxItemLevel,
      uint maxItemPerAccount,
      int npcContextualId,
      uint unsoldDelay)
    {
      this.quantities = quantities;
      this.types = types;
      this.taxPercentage = taxPercentage;
      this.taxModificationPercentage = taxModificationPercentage;
      this.maxItemLevel = maxItemLevel;
      this.maxItemPerAccount = maxItemPerAccount;
      this.npcContextualId = npcContextualId;
      this.unsoldDelay = unsoldDelay;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.quantities.Count);
      for (int index = 0; index < this.quantities.Count; ++index)
      {
        if (this.quantities[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.quantities[index] + ") on element 1 (starting at 1) of quantities.");
        writer.WriteVarInt((int) this.quantities[index]);
      }
      writer.WriteShort((short) this.types.Count);
      for (int index = 0; index < this.types.Count; ++index)
      {
        if (this.types[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.types[index] + ") on element 2 (starting at 1) of types.");
        writer.WriteVarInt((int) this.types[index]);
      }
      writer.WriteFloat((float) this.taxPercentage);
      writer.WriteFloat((float) this.taxModificationPercentage);
      if (this.maxItemLevel < 0U || this.maxItemLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.maxItemLevel + ") on element maxItemLevel.");
      writer.WriteByte((byte) this.maxItemLevel);
      if (this.maxItemPerAccount < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxItemPerAccount + ") on element maxItemPerAccount.");
      writer.WriteVarInt((int) this.maxItemPerAccount);
      writer.WriteInt(this.npcContextualId);
      if (this.unsoldDelay < 0U)
        throw new Exception("Forbidden value (" + (object) this.unsoldDelay + ") on element unsoldDelay.");
      writer.WriteVarShort((short) this.unsoldDelay);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of quantities.");
        this.quantities.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of types.");
        this.types.Add(num2);
      }
      this.taxPercentage = (double) reader.ReadFloat();
      this.taxModificationPercentage = (double) reader.ReadFloat();
      this.maxItemLevel = (uint) reader.ReadByte();
      if (this.maxItemLevel < 0U || this.maxItemLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.maxItemLevel + ") on element of SellerBuyerDescriptor.maxItemLevel.");
      this.maxItemPerAccount = reader.ReadVarUhInt();
      if (this.maxItemPerAccount < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxItemPerAccount + ") on element of SellerBuyerDescriptor.maxItemPerAccount.");
      this.npcContextualId = reader.ReadInt();
      this.unsoldDelay = (uint) reader.ReadVarUhShort();
      if (this.unsoldDelay < 0U)
        throw new Exception("Forbidden value (" + (object) this.unsoldDelay + ") on element of SellerBuyerDescriptor.unsoldDelay.");
    }
  }
}
