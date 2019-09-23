using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntMessage : NetworkMessage
  {
    public List<TreasureHuntStep> knownStepsList = new List<TreasureHuntStep>();
    public List<TreasureHuntFlag> flags = new List<TreasureHuntFlag>();
    public const uint Id = 6486;
    public uint questType;
    public double startMapId;
    public uint totalStepCount;
    public uint checkPointCurrent;
    public uint checkPointTotal;
    public int availableRetryCount;

    public override uint MessageId
    {
      get
      {
        return 6486;
      }
    }

    public TreasureHuntMessage()
    {
    }

    public TreasureHuntMessage(
      uint questType,
      double startMapId,
      List<TreasureHuntStep> knownStepsList,
      uint totalStepCount,
      uint checkPointCurrent,
      uint checkPointTotal,
      int availableRetryCount,
      List<TreasureHuntFlag> flags)
    {
      this.questType = questType;
      this.startMapId = startMapId;
      this.knownStepsList = knownStepsList;
      this.totalStepCount = totalStepCount;
      this.checkPointCurrent = checkPointCurrent;
      this.checkPointTotal = checkPointTotal;
      this.availableRetryCount = availableRetryCount;
      this.flags = flags;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.questType);
      if (this.startMapId < 0.0 || this.startMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.startMapId + ") on element startMapId.");
      writer.WriteDouble(this.startMapId);
      writer.WriteShort((short) this.knownStepsList.Count);
      for (int index = 0; index < this.knownStepsList.Count; ++index)
      {
        writer.WriteShort((short) this.knownStepsList[index].TypeId);
        this.knownStepsList[index].Serialize(writer);
      }
      if (this.totalStepCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.totalStepCount + ") on element totalStepCount.");
      writer.WriteByte((byte) this.totalStepCount);
      if (this.checkPointCurrent < 0U)
        throw new Exception("Forbidden value (" + (object) this.checkPointCurrent + ") on element checkPointCurrent.");
      writer.WriteVarInt((int) this.checkPointCurrent);
      if (this.checkPointTotal < 0U)
        throw new Exception("Forbidden value (" + (object) this.checkPointTotal + ") on element checkPointTotal.");
      writer.WriteVarInt((int) this.checkPointTotal);
      writer.WriteInt(this.availableRetryCount);
      writer.WriteShort((short) this.flags.Count);
      for (int index = 0; index < this.flags.Count; ++index)
        this.flags[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questType = (uint) reader.ReadByte();
      if (this.questType < 0U)
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntMessage.questType.");
      this.startMapId = reader.ReadDouble();
      if (this.startMapId < 0.0 || this.startMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.startMapId + ") on element of TreasureHuntMessage.startMapId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        TreasureHuntStep instance = ProtocolTypeManager.GetInstance<TreasureHuntStep>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.knownStepsList.Add(instance);
      }
      this.totalStepCount = (uint) reader.ReadByte();
      if (this.totalStepCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.totalStepCount + ") on element of TreasureHuntMessage.totalStepCount.");
      this.checkPointCurrent = reader.ReadVarUhInt();
      if (this.checkPointCurrent < 0U)
        throw new Exception("Forbidden value (" + (object) this.checkPointCurrent + ") on element of TreasureHuntMessage.checkPointCurrent.");
      this.checkPointTotal = reader.ReadVarUhInt();
      if (this.checkPointTotal < 0U)
        throw new Exception("Forbidden value (" + (object) this.checkPointTotal + ") on element of TreasureHuntMessage.checkPointTotal.");
      this.availableRetryCount = reader.ReadInt();
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        TreasureHuntFlag treasureHuntFlag = new TreasureHuntFlag();
        treasureHuntFlag.Deserialize(reader);
        this.flags.Add(treasureHuntFlag);
      }
    }
  }
}
