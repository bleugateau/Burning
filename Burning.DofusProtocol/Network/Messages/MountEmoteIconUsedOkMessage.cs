using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountEmoteIconUsedOkMessage : NetworkMessage
  {
    public const uint Id = 5978;
    public int mountId;
    public uint reactionType;

    public override uint MessageId
    {
      get
      {
        return 5978;
      }
    }

    public MountEmoteIconUsedOkMessage()
    {
    }

    public MountEmoteIconUsedOkMessage(int mountId, uint reactionType)
    {
      this.mountId = mountId;
      this.reactionType = reactionType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteVarInt(this.mountId);
      if (this.reactionType < 0U)
        throw new Exception("Forbidden value (" + (object) this.reactionType + ") on element reactionType.");
      writer.WriteByte((byte) this.reactionType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mountId = reader.ReadVarInt();
      this.reactionType = (uint) reader.ReadByte();
      if (this.reactionType < 0U)
        throw new Exception("Forbidden value (" + (object) this.reactionType + ") on element of MountEmoteIconUsedOkMessage.reactionType.");
    }
  }
}
