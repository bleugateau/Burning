using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShortcutBarSwapRequestMessage : NetworkMessage
  {
    public const uint Id = 6230;
    public uint barType;
    public uint firstSlot;
    public uint secondSlot;

    public override uint MessageId
    {
      get
      {
        return 6230;
      }
    }

    public ShortcutBarSwapRequestMessage()
    {
    }

    public ShortcutBarSwapRequestMessage(uint barType, uint firstSlot, uint secondSlot)
    {
      this.barType = barType;
      this.firstSlot = firstSlot;
      this.secondSlot = secondSlot;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.barType);
      if (this.firstSlot < 0U || this.firstSlot > 99U)
        throw new Exception("Forbidden value (" + (object) this.firstSlot + ") on element firstSlot.");
      writer.WriteByte((byte) this.firstSlot);
      if (this.secondSlot < 0U || this.secondSlot > 99U)
        throw new Exception("Forbidden value (" + (object) this.secondSlot + ") on element secondSlot.");
      writer.WriteByte((byte) this.secondSlot);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.barType = (uint) reader.ReadByte();
      if (this.barType < 0U)
        throw new Exception("Forbidden value (" + (object) this.barType + ") on element of ShortcutBarSwapRequestMessage.barType.");
      this.firstSlot = (uint) reader.ReadByte();
      if (this.firstSlot < 0U || this.firstSlot > 99U)
        throw new Exception("Forbidden value (" + (object) this.firstSlot + ") on element of ShortcutBarSwapRequestMessage.firstSlot.");
      this.secondSlot = (uint) reader.ReadByte();
      if (this.secondSlot < 0U || this.secondSlot > 99U)
        throw new Exception("Forbidden value (" + (object) this.secondSlot + ") on element of ShortcutBarSwapRequestMessage.secondSlot.");
    }
  }
}
