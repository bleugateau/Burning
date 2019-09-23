using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class BidExchangerObjectInfo
  {
    public List<ObjectEffect> effects = new List<ObjectEffect>();
    public List<double> prices = new List<double>();
    public const uint Id = 122;
    public uint objectUID;

    public virtual uint TypeId
    {
      get
      {
        return 122;
      }
    }

    public BidExchangerObjectInfo()
    {
    }

    public BidExchangerObjectInfo(uint objectUID, List<ObjectEffect> effects, List<double> prices)
    {
      this.objectUID = objectUID;
      this.effects = effects;
      this.prices = prices;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      writer.WriteShort((short) this.effects.Count);
      for (int index = 0; index < this.effects.Count; ++index)
      {
        writer.WriteShort((short) this.effects[index].TypeId);
        this.effects[index].Serialize(writer);
      }
      writer.WriteShort((short) this.prices.Count);
      for (int index = 0; index < this.prices.Count; ++index)
      {
        if (this.prices[index] < 0.0 || this.prices[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.prices[index] + ") on element 3 (starting at 1) of prices.");
        writer.WriteVarLong((long) this.prices[index]);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of BidExchangerObjectInfo.objectUID.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        ObjectEffect instance = ProtocolTypeManager.GetInstance<ObjectEffect>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.effects.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        double num3 = (double) reader.ReadVarUhLong();
        if (num3 < 0.0 || num3 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of prices.");
        this.prices.Add(num3);
      }
    }
  }
}
