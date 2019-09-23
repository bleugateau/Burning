using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class RecycleResultMessage : NetworkMessage
  {
    public const uint Id = 6601;
    public uint nuggetsForPrism;
    public uint nuggetsForPlayer;

    public override uint MessageId
    {
      get
      {
        return 6601;
      }
    }

    public RecycleResultMessage()
    {
    }

    public RecycleResultMessage(uint nuggetsForPrism, uint nuggetsForPlayer)
    {
      this.nuggetsForPrism = nuggetsForPrism;
      this.nuggetsForPlayer = nuggetsForPlayer;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.nuggetsForPrism < 0U)
        throw new Exception("Forbidden value (" + (object) this.nuggetsForPrism + ") on element nuggetsForPrism.");
      writer.WriteVarInt((int) this.nuggetsForPrism);
      if (this.nuggetsForPlayer < 0U)
        throw new Exception("Forbidden value (" + (object) this.nuggetsForPlayer + ") on element nuggetsForPlayer.");
      writer.WriteVarInt((int) this.nuggetsForPlayer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.nuggetsForPrism = reader.ReadVarUhInt();
      if (this.nuggetsForPrism < 0U)
        throw new Exception("Forbidden value (" + (object) this.nuggetsForPrism + ") on element of RecycleResultMessage.nuggetsForPrism.");
      this.nuggetsForPlayer = reader.ReadVarUhInt();
      if (this.nuggetsForPlayer < 0U)
        throw new Exception("Forbidden value (" + (object) this.nuggetsForPlayer + ") on element of RecycleResultMessage.nuggetsForPlayer.");
    }
  }
}
