using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class KohUpdateMessage : NetworkMessage
  {
    public List<AllianceInformations> alliances = new List<AllianceInformations>();
    public List<uint> allianceNbMembers = new List<uint>();
    public List<uint> allianceRoundWeigth = new List<uint>();
    public List<uint> allianceMatchScore = new List<uint>();
    public List<BasicAllianceInformations> allianceMapWinners = new List<BasicAllianceInformations>();
    public const uint Id = 6439;
    public uint allianceMapWinnerScore;
    public uint allianceMapMyAllianceScore;
    public double nextTickTime;

    public override uint MessageId
    {
      get
      {
        return 6439;
      }
    }

    public KohUpdateMessage()
    {
    }

    public KohUpdateMessage(
      List<AllianceInformations> alliances,
      List<uint> allianceNbMembers,
      List<uint> allianceRoundWeigth,
      List<uint> allianceMatchScore,
      List<BasicAllianceInformations> allianceMapWinners,
      uint allianceMapWinnerScore,
      uint allianceMapMyAllianceScore,
      double nextTickTime)
    {
      this.alliances = alliances;
      this.allianceNbMembers = allianceNbMembers;
      this.allianceRoundWeigth = allianceRoundWeigth;
      this.allianceMatchScore = allianceMatchScore;
      this.allianceMapWinners = allianceMapWinners;
      this.allianceMapWinnerScore = allianceMapWinnerScore;
      this.allianceMapMyAllianceScore = allianceMapMyAllianceScore;
      this.nextTickTime = nextTickTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.alliances.Count);
      for (int index = 0; index < this.alliances.Count; ++index)
        this.alliances[index].Serialize(writer);
      writer.WriteShort((short) this.allianceNbMembers.Count);
      for (int index = 0; index < this.allianceNbMembers.Count; ++index)
      {
        if (this.allianceNbMembers[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.allianceNbMembers[index] + ") on element 2 (starting at 1) of allianceNbMembers.");
        writer.WriteVarShort((short) this.allianceNbMembers[index]);
      }
      writer.WriteShort((short) this.allianceRoundWeigth.Count);
      for (int index = 0; index < this.allianceRoundWeigth.Count; ++index)
      {
        if (this.allianceRoundWeigth[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.allianceRoundWeigth[index] + ") on element 3 (starting at 1) of allianceRoundWeigth.");
        writer.WriteVarInt((int) this.allianceRoundWeigth[index]);
      }
      writer.WriteShort((short) this.allianceMatchScore.Count);
      for (int index = 0; index < this.allianceMatchScore.Count; ++index)
      {
        if (this.allianceMatchScore[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.allianceMatchScore[index] + ") on element 4 (starting at 1) of allianceMatchScore.");
        writer.WriteByte((byte) this.allianceMatchScore[index]);
      }
      writer.WriteShort((short) this.allianceMapWinners.Count);
      for (int index = 0; index < this.allianceMapWinners.Count; ++index)
        this.allianceMapWinners[index].Serialize(writer);
      if (this.allianceMapWinnerScore < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceMapWinnerScore + ") on element allianceMapWinnerScore.");
      writer.WriteVarInt((int) this.allianceMapWinnerScore);
      if (this.allianceMapMyAllianceScore < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceMapMyAllianceScore + ") on element allianceMapMyAllianceScore.");
      writer.WriteVarInt((int) this.allianceMapMyAllianceScore);
      if (this.nextTickTime < 0.0 || this.nextTickTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.nextTickTime + ") on element nextTickTime.");
      writer.WriteDouble(this.nextTickTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        AllianceInformations allianceInformations = new AllianceInformations();
        allianceInformations.Deserialize(reader);
        this.alliances.Add(allianceInformations);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        uint num3 = (uint) reader.ReadVarUhShort();
        if (num3 < 0U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of allianceNbMembers.");
        this.allianceNbMembers.Add(num3);
      }
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        uint num3 = reader.ReadVarUhInt();
        if (num3 < 0U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of allianceRoundWeigth.");
        this.allianceRoundWeigth.Add(num3);
      }
      uint num5 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num5; ++index)
      {
        uint num3 = (uint) reader.ReadByte();
        if (num3 < 0U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of allianceMatchScore.");
        this.allianceMatchScore.Add(num3);
      }
      uint num6 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num6; ++index)
      {
        BasicAllianceInformations allianceInformations = new BasicAllianceInformations();
        allianceInformations.Deserialize(reader);
        this.allianceMapWinners.Add(allianceInformations);
      }
      this.allianceMapWinnerScore = reader.ReadVarUhInt();
      if (this.allianceMapWinnerScore < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceMapWinnerScore + ") on element of KohUpdateMessage.allianceMapWinnerScore.");
      this.allianceMapMyAllianceScore = reader.ReadVarUhInt();
      if (this.allianceMapMyAllianceScore < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceMapMyAllianceScore + ") on element of KohUpdateMessage.allianceMapMyAllianceScore.");
      this.nextTickTime = reader.ReadDouble();
      if (this.nextTickTime < 0.0 || this.nextTickTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.nextTickTime + ") on element of KohUpdateMessage.nextTickTime.");
    }
  }
}
