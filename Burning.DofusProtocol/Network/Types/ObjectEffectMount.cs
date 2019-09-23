using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectMount : ObjectEffect
  {
    public List<ObjectEffectInteger> effects = new List<ObjectEffectInteger>();
    public List<uint> capacities = new List<uint>();
    public new const uint Id = 179;
    public double id;
    public double expirationDate;
    public uint model;
    public string name;
    public string owner;
    public uint level;
    public bool sex;
    public bool isRideable;
    public bool isFeconded;
    public bool isFecondationReady;
    public int reproductionCount;
    public uint reproductionCountMax;

    public override uint TypeId
    {
      get
      {
        return 179;
      }
    }

    public ObjectEffectMount()
    {
    }

    public ObjectEffectMount(
      uint actionId,
      double id,
      double expirationDate,
      uint model,
      string name,
      string owner,
      uint level,
      bool sex,
      bool isRideable,
      bool isFeconded,
      bool isFecondationReady,
      int reproductionCount,
      uint reproductionCountMax,
      List<ObjectEffectInteger> effects,
      List<uint> capacities)
      : base(actionId)
    {
      this.id = id;
      this.expirationDate = expirationDate;
      this.model = model;
      this.name = name;
      this.owner = owner;
      this.level = level;
      this.sex = sex;
      this.isRideable = isRideable;
      this.isFeconded = isFeconded;
      this.isFecondationReady = isFecondationReady;
      this.reproductionCount = reproductionCount;
      this.reproductionCountMax = reproductionCountMax;
      this.effects = effects;
      this.capacities = capacities;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.sex), (byte) 1, this.isRideable), (byte) 2, this.isFeconded), (byte) 3, this.isFecondationReady);
      writer.WriteByte((byte) num);
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarLong((long) this.id);
      if (this.expirationDate < 0.0 || this.expirationDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.expirationDate + ") on element expirationDate.");
      writer.WriteVarLong((long) this.expirationDate);
      if (this.model < 0U)
        throw new Exception("Forbidden value (" + (object) this.model + ") on element model.");
      writer.WriteVarInt((int) this.model);
      writer.WriteUTF(this.name);
      writer.WriteUTF(this.owner);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteByte((byte) this.level);
      writer.WriteVarInt(this.reproductionCount);
      if (this.reproductionCountMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.reproductionCountMax + ") on element reproductionCountMax.");
      writer.WriteVarInt((int) this.reproductionCountMax);
      writer.WriteShort((short) this.effects.Count);
      for (int index = 0; index < this.effects.Count; ++index)
        this.effects[index].Serialize(writer);
      writer.WriteShort((short) this.capacities.Count);
      for (int index = 0; index < this.capacities.Count; ++index)
      {
        if (this.capacities[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.capacities[index] + ") on element 14 (starting at 1) of capacities.");
        writer.WriteVarInt((int) this.capacities[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadByte();
      this.sex = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 0);
      this.isRideable = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 1);
      this.isFeconded = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 2);
      this.isFecondationReady = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 3);
      this.id = (double) reader.ReadVarUhLong();
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of ObjectEffectMount.id.");
      this.expirationDate = (double) reader.ReadVarUhLong();
      if (this.expirationDate < 0.0 || this.expirationDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.expirationDate + ") on element of ObjectEffectMount.expirationDate.");
      this.model = reader.ReadVarUhInt();
      if (this.model < 0U)
        throw new Exception("Forbidden value (" + (object) this.model + ") on element of ObjectEffectMount.model.");
      this.name = reader.ReadUTF();
      this.owner = reader.ReadUTF();
      this.level = (uint) reader.ReadByte();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of ObjectEffectMount.level.");
      this.reproductionCount = reader.ReadVarInt();
      this.reproductionCountMax = reader.ReadVarUhInt();
      if (this.reproductionCountMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.reproductionCountMax + ") on element of ObjectEffectMount.reproductionCountMax.");
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        ObjectEffectInteger objectEffectInteger = new ObjectEffectInteger();
        objectEffectInteger.Deserialize(reader);
        this.effects.Add(objectEffectInteger);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num4 = reader.ReadVarUhInt();
        if (num4 < 0U)
          throw new Exception("Forbidden value (" + (object) num4 + ") on elements of capacities.");
        this.capacities.Add(num4);
      }
    }
  }
}
