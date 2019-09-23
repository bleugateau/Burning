using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
  {
    public List<int> npcsIdsWithQuest = new List<int>();
    public List<GameRolePlayNpcQuestFlag> questFlags = new List<GameRolePlayNpcQuestFlag>();
    public List<int> npcsIdsWithoutQuest = new List<int>();
    public const uint Id = 5642;
    public double mapId;

    public override uint MessageId
    {
      get
      {
        return 5642;
      }
    }

    public MapNpcsQuestStatusUpdateMessage()
    {
    }

    public MapNpcsQuestStatusUpdateMessage(
      double mapId,
      List<int> npcsIdsWithQuest,
      List<GameRolePlayNpcQuestFlag> questFlags,
      List<int> npcsIdsWithoutQuest)
    {
      this.mapId = mapId;
      this.npcsIdsWithQuest = npcsIdsWithQuest;
      this.questFlags = questFlags;
      this.npcsIdsWithoutQuest = npcsIdsWithoutQuest;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      writer.WriteShort((short) this.npcsIdsWithQuest.Count);
      for (int index = 0; index < this.npcsIdsWithQuest.Count; ++index)
        writer.WriteInt(this.npcsIdsWithQuest[index]);
      writer.WriteShort((short) this.questFlags.Count);
      for (int index = 0; index < this.questFlags.Count; ++index)
        this.questFlags[index].Serialize(writer);
      writer.WriteShort((short) this.npcsIdsWithoutQuest.Count);
      for (int index = 0; index < this.npcsIdsWithoutQuest.Count; ++index)
        writer.WriteInt(this.npcsIdsWithoutQuest[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of MapNpcsQuestStatusUpdateMessage.mapId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
        this.npcsIdsWithQuest.Add(reader.ReadInt());
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        GameRolePlayNpcQuestFlag playNpcQuestFlag = new GameRolePlayNpcQuestFlag();
        playNpcQuestFlag.Deserialize(reader);
        this.questFlags.Add(playNpcQuestFlag);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
        this.npcsIdsWithoutQuest.Add(reader.ReadInt());
    }
  }
}
