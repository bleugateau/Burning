using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class BreachReward
  {
    public List<uint> buyLocks = new List<uint>();
    public const uint Id = 559;
    public uint id;
    public string buyCriterion;
    public bool bought;
    public uint price;

    public virtual uint TypeId
    {
      get
      {
        return 559;
      }
    }

    public BreachReward()
    {
    }

    public BreachReward(
      uint id,
      List<uint> buyLocks,
      string buyCriterion,
      bool bought,
      uint price)
    {
      this.id = id;
      this.buyLocks = buyLocks;
      this.buyCriterion = buyCriterion;
      this.bought = bought;
      this.price = price;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarInt((int) this.id);
      writer.WriteShort((short) this.buyLocks.Count);
      for (int index = 0; index < this.buyLocks.Count; ++index)
        writer.WriteByte((byte) this.buyLocks[index]);
      writer.WriteUTF(this.buyCriterion);
      writer.WriteBoolean(this.bought);
      if (this.price < 0U)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarInt((int) this.price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadVarUhInt();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of BreachReward.id.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of buyLocks.");
        this.buyLocks.Add(num2);
      }
      this.buyCriterion = reader.ReadUTF();
      this.bought = reader.ReadBoolean();
      this.price = reader.ReadVarUhInt();
      if (this.price < 0U)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of BreachReward.price.");
    }
  }
}
