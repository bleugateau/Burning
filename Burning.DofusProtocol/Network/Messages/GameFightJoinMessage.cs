using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightJoinMessage : NetworkMessage
  {
    public const uint Id = 702;
    public bool isTeamPhase;
    public bool canBeCancelled;
    public bool canSayReady;
    public bool isFightStarted;
    public uint timeMaxBeforeFightStart;
    public uint fightType;

    public override uint MessageId
    {
      get
      {
        return 702;
      }
    }

    public GameFightJoinMessage()
    {
    }

    public GameFightJoinMessage(
      bool isTeamPhase,
      bool canBeCancelled,
      bool canSayReady,
      bool isFightStarted,
      uint timeMaxBeforeFightStart,
      uint fightType)
    {
      this.isTeamPhase = isTeamPhase;
      this.canBeCancelled = canBeCancelled;
      this.canSayReady = canSayReady;
      this.isFightStarted = isFightStarted;
      this.timeMaxBeforeFightStart = timeMaxBeforeFightStart;
      this.fightType = fightType;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.isTeamPhase), (byte) 1, this.canBeCancelled), (byte) 2, this.canSayReady), (byte) 3, this.isFightStarted);
      writer.WriteByte((byte) num);
      if (this.timeMaxBeforeFightStart < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeMaxBeforeFightStart + ") on element timeMaxBeforeFightStart.");
      writer.WriteShort((short) this.timeMaxBeforeFightStart);
      writer.WriteByte((byte) this.fightType);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.isTeamPhase = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.canBeCancelled = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.canSayReady = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 2);
      this.isFightStarted = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 3);
      this.timeMaxBeforeFightStart = (uint) reader.ReadShort();
      if (this.timeMaxBeforeFightStart < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeMaxBeforeFightStart + ") on element of GameFightJoinMessage.timeMaxBeforeFightStart.");
      this.fightType = (uint) reader.ReadByte();
      if (this.fightType < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightType + ") on element of GameFightJoinMessage.fightType.");
    }
  }
}
