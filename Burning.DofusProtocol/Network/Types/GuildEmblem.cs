using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildEmblem
  {
    public const uint Id = 87;
    public uint symbolShape;
    public int symbolColor;
    public uint backgroundShape;
    public int backgroundColor;

    public virtual uint TypeId
    {
      get
      {
        return 87;
      }
    }

    public GuildEmblem()
    {
    }

    public GuildEmblem(
      uint symbolShape,
      int symbolColor,
      uint backgroundShape,
      int backgroundColor)
    {
      this.symbolShape = symbolShape;
      this.symbolColor = symbolColor;
      this.backgroundShape = backgroundShape;
      this.backgroundColor = backgroundColor;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.symbolShape < 0U)
        throw new Exception("Forbidden value (" + (object) this.symbolShape + ") on element symbolShape.");
      writer.WriteVarShort((short) this.symbolShape);
      writer.WriteInt(this.symbolColor);
      if (this.backgroundShape < 0U)
        throw new Exception("Forbidden value (" + (object) this.backgroundShape + ") on element backgroundShape.");
      writer.WriteByte((byte) this.backgroundShape);
      writer.WriteInt(this.backgroundColor);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.symbolShape = (uint) reader.ReadVarUhShort();
      if (this.symbolShape < 0U)
        throw new Exception("Forbidden value (" + (object) this.symbolShape + ") on element of GuildEmblem.symbolShape.");
      this.symbolColor = reader.ReadInt();
      this.backgroundShape = (uint) reader.ReadByte();
      if (this.backgroundShape < 0U)
        throw new Exception("Forbidden value (" + (object) this.backgroundShape + ") on element of GuildEmblem.backgroundShape.");
      this.backgroundColor = reader.ReadInt();
    }
  }
}
