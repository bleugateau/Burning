using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HavenBagDailyLoteryMessage : NetworkMessage
  {
    public const uint Id = 6644;
    public uint returnType;
    public string gameActionId;

    public override uint MessageId
    {
      get
      {
        return 6644;
      }
    }

    public HavenBagDailyLoteryMessage()
    {
    }

    public HavenBagDailyLoteryMessage(uint returnType, string gameActionId)
    {
      this.returnType = returnType;
      this.gameActionId = gameActionId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.returnType);
      writer.WriteUTF(this.gameActionId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.returnType = (uint) reader.ReadByte();
      if (this.returnType < 0U)
        throw new Exception("Forbidden value (" + (object) this.returnType + ") on element of HavenBagDailyLoteryMessage.returnType.");
      this.gameActionId = reader.ReadUTF();
    }
  }
}
