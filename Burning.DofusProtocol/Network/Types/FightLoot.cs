using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightLoot
  {
    public List<uint> objects = new List<uint>();
    public const uint Id = 41;
    public double kamas;

    public virtual uint TypeId
    {
      get
      {
        return 41;
      }
    }

    public FightLoot()
    {
    }

    public FightLoot(List<uint> objects, double kamas)
    {
      this.objects = objects;
      this.kamas = kamas;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objects.Count);
      for (int index = 0; index < this.objects.Count; ++index)
      {
        if (this.objects[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.objects[index] + ") on element 1 (starting at 1) of objects.");
        writer.WriteVarInt((int) this.objects[index]);
      }
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element kamas.");
      writer.WriteVarLong((long) this.kamas);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of objects.");
        this.objects.Add(num2);
      }
      this.kamas = (double) reader.ReadVarUhLong();
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element of FightLoot.kamas.");
    }
  }
}
