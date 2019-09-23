using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildCharacsUpgradeRequestMessage : NetworkMessage
  {
    public const uint Id = 5706;
    public uint charaTypeTarget;

    public override uint MessageId
    {
      get
      {
        return 5706;
      }
    }

    public GuildCharacsUpgradeRequestMessage()
    {
    }

    public GuildCharacsUpgradeRequestMessage(uint charaTypeTarget)
    {
      this.charaTypeTarget = charaTypeTarget;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.charaTypeTarget);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.charaTypeTarget = (uint) reader.ReadByte();
      if (this.charaTypeTarget < 0U)
        throw new Exception("Forbidden value (" + (object) this.charaTypeTarget + ") on element of GuildCharacsUpgradeRequestMessage.charaTypeTarget.");
    }
  }
}
