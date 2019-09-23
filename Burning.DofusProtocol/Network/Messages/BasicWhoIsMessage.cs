using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicWhoIsMessage : NetworkMessage
  {
    public List<AbstractSocialGroupInfos> socialGroups = new List<AbstractSocialGroupInfos>();
    public const uint Id = 180;
    public bool self;
    public int position;
    public string accountNickname;
    public uint accountId;
    public string playerName;
    public double playerId;
    public int areaId;
    public int serverId;
    public int originServerId;
    public bool verbose;
    public uint playerState;

    public override uint MessageId
    {
      get
      {
        return 180;
      }
    }

    public BasicWhoIsMessage()
    {
    }

    public BasicWhoIsMessage(
      bool self,
      int position,
      string accountNickname,
      uint accountId,
      string playerName,
      double playerId,
      int areaId,
      int serverId,
      int originServerId,
      List<AbstractSocialGroupInfos> socialGroups,
      bool verbose,
      uint playerState)
    {
      this.self = self;
      this.position = position;
      this.accountNickname = accountNickname;
      this.accountId = accountId;
      this.playerName = playerName;
      this.playerId = playerId;
      this.areaId = areaId;
      this.serverId = serverId;
      this.originServerId = originServerId;
      this.socialGroups = socialGroups;
      this.verbose = verbose;
      this.playerState = playerState;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.self), (byte) 1, this.verbose);
      writer.WriteByte((byte) num);
      writer.WriteByte((byte) this.position);
      writer.WriteUTF(this.accountNickname);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      writer.WriteUTF(this.playerName);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteShort((short) this.areaId);
      writer.WriteShort((short) this.serverId);
      writer.WriteShort((short) this.originServerId);
      writer.WriteShort((short) this.socialGroups.Count);
      for (int index = 0; index < this.socialGroups.Count; ++index)
      {
        writer.WriteShort((short) this.socialGroups[index].TypeId);
        this.socialGroups[index].Serialize(writer);
      }
      writer.WriteByte((byte) this.playerState);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadByte();
      this.self = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 0);
      this.verbose = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 1);
      this.position = (int) reader.ReadByte();
      this.accountNickname = reader.ReadUTF();
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of BasicWhoIsMessage.accountId.");
      this.playerName = reader.ReadUTF();
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of BasicWhoIsMessage.playerId.");
      this.areaId = (int) reader.ReadShort();
      this.serverId = (int) reader.ReadShort();
      this.originServerId = (int) reader.ReadShort();
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        AbstractSocialGroupInfos instance = ProtocolTypeManager.GetInstance<AbstractSocialGroupInfos>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.socialGroups.Add(instance);
      }
      this.playerState = (uint) reader.ReadByte();
      if (this.playerState < 0U)
        throw new Exception("Forbidden value (" + (object) this.playerState + ") on element of BasicWhoIsMessage.playerState.");
    }
  }
}
