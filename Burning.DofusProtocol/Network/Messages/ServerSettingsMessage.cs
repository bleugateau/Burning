using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ServerSettingsMessage : NetworkMessage
  {
    public const uint Id = 6340;
    public string lang;
    public uint community;
    public int gameType;
    public bool isMonoAccount;
    public uint arenaLeaveBanTime;
    public uint itemMaxLevel;
    public bool hasFreeAutopilot;

    public override uint MessageId
    {
      get
      {
        return 6340;
      }
    }

    public ServerSettingsMessage()
    {
    }

    public ServerSettingsMessage(
      string lang,
      uint community,
      int gameType,
      bool isMonoAccount,
      uint arenaLeaveBanTime,
      uint itemMaxLevel,
      bool hasFreeAutopilot)
    {
      this.lang = lang;
      this.community = community;
      this.gameType = gameType;
      this.isMonoAccount = isMonoAccount;
      this.arenaLeaveBanTime = arenaLeaveBanTime;
      this.itemMaxLevel = itemMaxLevel;
      this.hasFreeAutopilot = hasFreeAutopilot;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.isMonoAccount), (byte) 1, this.hasFreeAutopilot);
      writer.WriteByte((byte) num);
      writer.WriteUTF(this.lang);
      if (this.community < 0U)
        throw new Exception("Forbidden value (" + (object) this.community + ") on element community.");
      writer.WriteByte((byte) this.community);
      writer.WriteByte((byte) this.gameType);
      if (this.arenaLeaveBanTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.arenaLeaveBanTime + ") on element arenaLeaveBanTime.");
      writer.WriteVarShort((short) this.arenaLeaveBanTime);
      if (this.itemMaxLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.itemMaxLevel + ") on element itemMaxLevel.");
      writer.WriteInt((int) this.itemMaxLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.isMonoAccount = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.hasFreeAutopilot = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.lang = reader.ReadUTF();
      this.community = (uint) reader.ReadByte();
      if (this.community < 0U)
        throw new Exception("Forbidden value (" + (object) this.community + ") on element of ServerSettingsMessage.community.");
      this.gameType = (int) reader.ReadByte();
      this.arenaLeaveBanTime = (uint) reader.ReadVarUhShort();
      if (this.arenaLeaveBanTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.arenaLeaveBanTime + ") on element of ServerSettingsMessage.arenaLeaveBanTime.");
      this.itemMaxLevel = (uint) reader.ReadInt();
      if (this.itemMaxLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.itemMaxLevel + ") on element of ServerSettingsMessage.itemMaxLevel.");
    }
  }
}
