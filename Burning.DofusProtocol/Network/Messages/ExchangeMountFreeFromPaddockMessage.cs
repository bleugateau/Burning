using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeMountFreeFromPaddockMessage : NetworkMessage
  {
    public const uint Id = 6055;
    public string name;
    public int worldX;
    public int worldY;
    public string liberator;

    public override uint MessageId
    {
      get
      {
        return 6055;
      }
    }

    public ExchangeMountFreeFromPaddockMessage()
    {
    }

    public ExchangeMountFreeFromPaddockMessage(
      string name,
      int worldX,
      int worldY,
      string liberator)
    {
      this.name = name;
      this.worldX = worldX;
      this.worldY = worldY;
      this.liberator = liberator;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      writer.WriteUTF(this.liberator);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.name = reader.ReadUTF();
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of ExchangeMountFreeFromPaddockMessage.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of ExchangeMountFreeFromPaddockMessage.worldY.");
      this.liberator = reader.ReadUTF();
    }
  }
}
