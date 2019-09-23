using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class MountClientData
  {
    public List<uint> ancestor = new List<uint>();
    public List<uint> behaviors = new List<uint>();
    public List<ObjectEffectInteger> effectList = new List<ObjectEffectInteger>();
    public const uint Id = 178;
    public double id;
    public uint model;
    public string name;
    public bool sex;
    public uint ownerId;
    public double experience;
    public double experienceForLevel;
    public double experienceForNextLevel;
    public uint level;
    public bool isRideable;
    public uint maxPods;
    public bool isWild;
    public uint stamina;
    public uint staminaMax;
    public uint maturity;
    public uint maturityForAdult;
    public uint energy;
    public uint energyMax;
    public int serenity;
    public int aggressivityMax;
    public uint serenityMax;
    public uint love;
    public uint loveMax;
    public int fecondationTime;
    public bool isFecondationReady;
    public uint boostLimiter;
    public double boostMax;
    public int reproductionCount;
    public uint reproductionCountMax;
    public uint harnessGID;
    public bool useHarnessColors;

    public virtual uint TypeId
    {
      get
      {
        return 178;
      }
    }

    public MountClientData()
    {
    }

    public MountClientData(
      double id,
      uint model,
      List<uint> ancestor,
      List<uint> behaviors,
      string name,
      bool sex,
      uint ownerId,
      double experience,
      double experienceForLevel,
      double experienceForNextLevel,
      uint level,
      bool isRideable,
      uint maxPods,
      bool isWild,
      uint stamina,
      uint staminaMax,
      uint maturity,
      uint maturityForAdult,
      uint energy,
      uint energyMax,
      int serenity,
      int aggressivityMax,
      uint serenityMax,
      uint love,
      uint loveMax,
      int fecondationTime,
      bool isFecondationReady,
      uint boostLimiter,
      double boostMax,
      int reproductionCount,
      uint reproductionCountMax,
      uint harnessGID,
      bool useHarnessColors,
      List<ObjectEffectInteger> effectList)
    {
      this.id = id;
      this.model = model;
      this.ancestor = ancestor;
      this.behaviors = behaviors;
      this.name = name;
      this.sex = sex;
      this.ownerId = ownerId;
      this.experience = experience;
      this.experienceForLevel = experienceForLevel;
      this.experienceForNextLevel = experienceForNextLevel;
      this.level = level;
      this.isRideable = isRideable;
      this.maxPods = maxPods;
      this.isWild = isWild;
      this.stamina = stamina;
      this.staminaMax = staminaMax;
      this.maturity = maturity;
      this.maturityForAdult = maturityForAdult;
      this.energy = energy;
      this.energyMax = energyMax;
      this.serenity = serenity;
      this.aggressivityMax = aggressivityMax;
      this.serenityMax = serenityMax;
      this.love = love;
      this.loveMax = loveMax;
      this.fecondationTime = fecondationTime;
      this.isFecondationReady = isFecondationReady;
      this.boostLimiter = boostLimiter;
      this.boostMax = boostMax;
      this.reproductionCount = reproductionCount;
      this.reproductionCountMax = reproductionCountMax;
      this.harnessGID = harnessGID;
      this.useHarnessColors = useHarnessColors;
      this.effectList = effectList;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.sex), (byte) 1, this.isRideable), (byte) 2, this.isWild), (byte) 3, this.isFecondationReady), (byte) 4, this.useHarnessColors);
      writer.WriteByte((byte) num);
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      if (this.model < 0U)
        throw new Exception("Forbidden value (" + (object) this.model + ") on element model.");
      writer.WriteVarInt((int) this.model);
      writer.WriteShort((short) this.ancestor.Count);
      for (int index = 0; index < this.ancestor.Count; ++index)
      {
        if (this.ancestor[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.ancestor[index] + ") on element 3 (starting at 1) of ancestor.");
        writer.WriteInt((int) this.ancestor[index]);
      }
      writer.WriteShort((short) this.behaviors.Count);
      for (int index = 0; index < this.behaviors.Count; ++index)
      {
        if (this.behaviors[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.behaviors[index] + ") on element 4 (starting at 1) of behaviors.");
        writer.WriteInt((int) this.behaviors[index]);
      }
      writer.WriteUTF(this.name);
      if (this.ownerId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ownerId + ") on element ownerId.");
      writer.WriteInt((int) this.ownerId);
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteVarLong((long) this.experience);
      if (this.experienceForLevel < 0.0 || this.experienceForLevel > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForLevel + ") on element experienceForLevel.");
      writer.WriteVarLong((long) this.experienceForLevel);
      if (this.experienceForNextLevel < -9.00719925474099E+15 || this.experienceForNextLevel > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForNextLevel + ") on element experienceForNextLevel.");
      writer.WriteDouble(this.experienceForNextLevel);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteByte((byte) this.level);
      if (this.maxPods < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxPods + ") on element maxPods.");
      writer.WriteVarInt((int) this.maxPods);
      if (this.stamina < 0U)
        throw new Exception("Forbidden value (" + (object) this.stamina + ") on element stamina.");
      writer.WriteVarInt((int) this.stamina);
      if (this.staminaMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.staminaMax + ") on element staminaMax.");
      writer.WriteVarInt((int) this.staminaMax);
      if (this.maturity < 0U)
        throw new Exception("Forbidden value (" + (object) this.maturity + ") on element maturity.");
      writer.WriteVarInt((int) this.maturity);
      if (this.maturityForAdult < 0U)
        throw new Exception("Forbidden value (" + (object) this.maturityForAdult + ") on element maturityForAdult.");
      writer.WriteVarInt((int) this.maturityForAdult);
      if (this.energy < 0U)
        throw new Exception("Forbidden value (" + (object) this.energy + ") on element energy.");
      writer.WriteVarInt((int) this.energy);
      if (this.energyMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.energyMax + ") on element energyMax.");
      writer.WriteVarInt((int) this.energyMax);
      writer.WriteInt(this.serenity);
      writer.WriteInt(this.aggressivityMax);
      if (this.serenityMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.serenityMax + ") on element serenityMax.");
      writer.WriteVarInt((int) this.serenityMax);
      if (this.love < 0U)
        throw new Exception("Forbidden value (" + (object) this.love + ") on element love.");
      writer.WriteVarInt((int) this.love);
      if (this.loveMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.loveMax + ") on element loveMax.");
      writer.WriteVarInt((int) this.loveMax);
      writer.WriteInt(this.fecondationTime);
      if (this.boostLimiter < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostLimiter + ") on element boostLimiter.");
      writer.WriteInt((int) this.boostLimiter);
      if (this.boostMax < -9.00719925474099E+15 || this.boostMax > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.boostMax + ") on element boostMax.");
      writer.WriteDouble(this.boostMax);
      writer.WriteInt(this.reproductionCount);
      if (this.reproductionCountMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.reproductionCountMax + ") on element reproductionCountMax.");
      writer.WriteVarInt((int) this.reproductionCountMax);
      if (this.harnessGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.harnessGID + ") on element harnessGID.");
      writer.WriteVarShort((short) this.harnessGID);
      writer.WriteShort((short) this.effectList.Count);
      for (int index = 0; index < this.effectList.Count; ++index)
        this.effectList[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadByte();
      this.sex = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 0);
      this.isRideable = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 1);
      this.isWild = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 2);
      this.isFecondationReady = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 3);
      this.useHarnessColors = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 4);
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of MountClientData.id.");
      this.model = reader.ReadVarUhInt();
      if (this.model < 0U)
        throw new Exception("Forbidden value (" + (object) this.model + ") on element of MountClientData.model.");
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        uint num3 = (uint) reader.ReadInt();
        if (num3 < 0U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of ancestor.");
        this.ancestor.Add(num3);
      }
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        uint num3 = (uint) reader.ReadInt();
        if (num3 < 0U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of behaviors.");
        this.behaviors.Add(num3);
      }
      this.name = reader.ReadUTF();
      this.ownerId = (uint) reader.ReadInt();
      if (this.ownerId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ownerId + ") on element of MountClientData.ownerId.");
      this.experience = (double) reader.ReadVarUhLong();
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of MountClientData.experience.");
      this.experienceForLevel = (double) reader.ReadVarUhLong();
      if (this.experienceForLevel < 0.0 || this.experienceForLevel > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForLevel + ") on element of MountClientData.experienceForLevel.");
      this.experienceForNextLevel = reader.ReadDouble();
      if (this.experienceForNextLevel < -9.00719925474099E+15 || this.experienceForNextLevel > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForNextLevel + ") on element of MountClientData.experienceForNextLevel.");
      this.level = (uint) reader.ReadByte();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of MountClientData.level.");
      this.maxPods = reader.ReadVarUhInt();
      if (this.maxPods < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxPods + ") on element of MountClientData.maxPods.");
      this.stamina = reader.ReadVarUhInt();
      if (this.stamina < 0U)
        throw new Exception("Forbidden value (" + (object) this.stamina + ") on element of MountClientData.stamina.");
      this.staminaMax = reader.ReadVarUhInt();
      if (this.staminaMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.staminaMax + ") on element of MountClientData.staminaMax.");
      this.maturity = reader.ReadVarUhInt();
      if (this.maturity < 0U)
        throw new Exception("Forbidden value (" + (object) this.maturity + ") on element of MountClientData.maturity.");
      this.maturityForAdult = reader.ReadVarUhInt();
      if (this.maturityForAdult < 0U)
        throw new Exception("Forbidden value (" + (object) this.maturityForAdult + ") on element of MountClientData.maturityForAdult.");
      this.energy = reader.ReadVarUhInt();
      if (this.energy < 0U)
        throw new Exception("Forbidden value (" + (object) this.energy + ") on element of MountClientData.energy.");
      this.energyMax = reader.ReadVarUhInt();
      if (this.energyMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.energyMax + ") on element of MountClientData.energyMax.");
      this.serenity = reader.ReadInt();
      this.aggressivityMax = reader.ReadInt();
      this.serenityMax = reader.ReadVarUhInt();
      if (this.serenityMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.serenityMax + ") on element of MountClientData.serenityMax.");
      this.love = reader.ReadVarUhInt();
      if (this.love < 0U)
        throw new Exception("Forbidden value (" + (object) this.love + ") on element of MountClientData.love.");
      this.loveMax = reader.ReadVarUhInt();
      if (this.loveMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.loveMax + ") on element of MountClientData.loveMax.");
      this.fecondationTime = reader.ReadInt();
      this.boostLimiter = (uint) reader.ReadInt();
      if (this.boostLimiter < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostLimiter + ") on element of MountClientData.boostLimiter.");
      this.boostMax = reader.ReadDouble();
      if (this.boostMax < -9.00719925474099E+15 || this.boostMax > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.boostMax + ") on element of MountClientData.boostMax.");
      this.reproductionCount = reader.ReadInt();
      this.reproductionCountMax = reader.ReadVarUhInt();
      if (this.reproductionCountMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.reproductionCountMax + ") on element of MountClientData.reproductionCountMax.");
      this.harnessGID = (uint) reader.ReadVarUhShort();
      if (this.harnessGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.harnessGID + ") on element of MountClientData.harnessGID.");
      uint num5 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num5; ++index)
      {
        ObjectEffectInteger objectEffectInteger = new ObjectEffectInteger();
        objectEffectInteger.Deserialize(reader);
        this.effectList.Add(objectEffectInteger);
      }
    }
  }
}
