using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StartupActionFinishedMessage : NetworkMessage
  {
    public const uint Id = 1304;
    public bool success;
    public uint actionId;
    public bool automaticAction;

    public override uint MessageId
    {
      get
      {
        return 1304;
      }
    }

    public StartupActionFinishedMessage()
    {
    }

    public StartupActionFinishedMessage(bool success, uint actionId, bool automaticAction)
    {
      this.success = success;
      this.actionId = actionId;
      this.automaticAction = automaticAction;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.success), (byte) 1, this.automaticAction);
      writer.WriteByte((byte) num);
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element actionId.");
      writer.WriteInt((int) this.actionId);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.success = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.automaticAction = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.actionId = (uint) reader.ReadInt();
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element of StartupActionFinishedMessage.actionId.");
    }
  }
}
