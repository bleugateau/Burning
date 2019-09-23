using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareCreationRequestMessage : NetworkMessage
  {
    public List<DareCriteria> criterions = new List<DareCriteria>();
    public const uint Id = 6665;
    public double subscriptionFee;
    public double jackpot;
    public uint maxCountWinners;
    public uint delayBeforeStart;
    public uint duration;
    public bool isPrivate;
    public bool isForGuild;
    public bool isForAlliance;
    public bool needNotifications;

    public override uint MessageId
    {
      get
      {
        return 6665;
      }
    }

    public DareCreationRequestMessage()
    {
    }

    public DareCreationRequestMessage(
      double subscriptionFee,
      double jackpot,
      uint maxCountWinners,
      uint delayBeforeStart,
      uint duration,
      bool isPrivate,
      bool isForGuild,
      bool isForAlliance,
      bool needNotifications,
      List<DareCriteria> criterions)
    {
      this.subscriptionFee = subscriptionFee;
      this.jackpot = jackpot;
      this.maxCountWinners = maxCountWinners;
      this.delayBeforeStart = delayBeforeStart;
      this.duration = duration;
      this.isPrivate = isPrivate;
      this.isForGuild = isForGuild;
      this.isForAlliance = isForAlliance;
      this.needNotifications = needNotifications;
      this.criterions = criterions;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.isPrivate), (byte) 1, this.isForGuild), (byte) 2, this.isForAlliance), (byte) 3, this.needNotifications);
      writer.WriteByte((byte) num);
      if (this.subscriptionFee < 0.0 || this.subscriptionFee > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionFee + ") on element subscriptionFee.");
      writer.WriteVarLong((long) this.subscriptionFee);
      if (this.jackpot < 0.0 || this.jackpot > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jackpot + ") on element jackpot.");
      writer.WriteVarLong((long) this.jackpot);
      if (this.maxCountWinners < 0U || this.maxCountWinners > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.maxCountWinners + ") on element maxCountWinners.");
      writer.WriteShort((short) this.maxCountWinners);
      if (this.delayBeforeStart < 0U || this.delayBeforeStart > uint.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.delayBeforeStart + ") on element delayBeforeStart.");
      writer.WriteUInt(this.delayBeforeStart);
      if (this.duration < 0U || this.duration > uint.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element duration.");
      writer.WriteUInt(this.duration);
      writer.WriteShort((short) this.criterions.Count);
      for (int index = 0; index < this.criterions.Count; ++index)
        this.criterions[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadByte();
      this.isPrivate = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 0);
      this.isForGuild = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 1);
      this.isForAlliance = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 2);
      this.needNotifications = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 3);
      this.subscriptionFee = (double) reader.ReadVarUhLong();
      if (this.subscriptionFee < 0.0 || this.subscriptionFee > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionFee + ") on element of DareCreationRequestMessage.subscriptionFee.");
      this.jackpot = (double) reader.ReadVarUhLong();
      if (this.jackpot < 0.0 || this.jackpot > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jackpot + ") on element of DareCreationRequestMessage.jackpot.");
      this.maxCountWinners = (uint) reader.ReadUShort();
      if (this.maxCountWinners < 0U || this.maxCountWinners > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.maxCountWinners + ") on element of DareCreationRequestMessage.maxCountWinners.");
      this.delayBeforeStart = reader.ReadUInt();
      if (this.delayBeforeStart < 0U || this.delayBeforeStart > uint.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.delayBeforeStart + ") on element of DareCreationRequestMessage.delayBeforeStart.");
      this.duration = reader.ReadUInt();
      if (this.duration < 0U || this.duration > uint.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element of DareCreationRequestMessage.duration.");
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        DareCriteria dareCriteria = new DareCriteria();
        dareCriteria.Deserialize(reader);
        this.criterions.Add(dareCriteria);
      }
    }
  }
}
