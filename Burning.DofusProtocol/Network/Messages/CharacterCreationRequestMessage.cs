using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterCreationRequestMessage : NetworkMessage
  {
    public const uint Id = 160;
    public string name;
    public int breed;
    public bool sex;
    public uint cosmeticId;
    public int[] colors;

    public override uint MessageId
    {
      get
      {
        return 160;
      }
    }

    public CharacterCreationRequestMessage()
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
      for (int index = 0; index < 5; ++index)
        writer.WriteInt(this.colors[index]);
      if ((ulong) this.cosmeticId < 0UL)
        throw new Exception("Forbidden value (" + (object) this.cosmeticId + ") on element cosmeticId.");
      writer.WriteVarShort((short) this.cosmeticId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.colors = new int[5];
      this.name = reader.ReadUTF();
      this.breed = (int) reader.ReadByte();
      if (this.breed < 1 || this.breed > 18)
        throw new Exception("Forbidden value (" + (object) this.breed + ") on element of CharacterCreationRequestMessage.breed.");
      this.sex = reader.ReadBoolean();
      for (int index = 0; index < 5; ++index)
        this.colors[index] = reader.ReadInt();
      this.cosmeticId = (uint) reader.ReadVarUhShort();
      if ((ulong) this.cosmeticId < 0UL)
        throw new Exception("Forbidden value (" + (object) this.cosmeticId + ") on element of CharacterCreationRequestMessage.cosmeticId.");
    }

    public CharacterCreationRequestMessage(
      string name,
      int breed,
      bool sex,
      int[] colors,
      uint cosmeticId)
    {
      this.name = name;
      this.breed = breed;
      this.sex = sex;
      this.colors = colors;
      this.cosmeticId = cosmeticId;
    }
  }
}
