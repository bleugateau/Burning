using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameServerInformations
  {
    public const uint Id = 25;
    public uint id;
    public int type;
    public bool isMonoAccount;
    public uint status;
    public uint completion;
    public bool isSelectable;
    public uint charactersCount;
    public uint charactersSlots;
    public double date;

    public virtual uint TypeId
    {
      get
      {
        return 25;
      }
    }

    public GameServerInformations()
    {
    }

    public GameServerInformations(
      uint id,
      int type,
      bool isMonoAccount,
      uint status,
      uint completion,
      bool isSelectable,
      uint charactersCount,
      uint charactersSlots,
      double date)
    {
      this.id = id;
      this.type = type;
      this.isMonoAccount = isMonoAccount;
      this.status = status;
      this.completion = completion;
      this.isSelectable = isSelectable;
      this.charactersCount = charactersCount;
      this.charactersSlots = charactersSlots;
      this.date = date;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.isMonoAccount), (byte) 1, this.isSelectable);
      writer.WriteByte((byte) num);
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      writer.WriteByte((byte) this.type);
      writer.WriteByte((byte) this.status);
      writer.WriteByte((byte) this.completion);
      if (this.charactersCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.charactersCount + ") on element charactersCount.");
      writer.WriteByte((byte) this.charactersCount);
      if (this.charactersSlots < 0U)
        throw new Exception("Forbidden value (" + (object) this.charactersSlots + ") on element charactersSlots.");
      writer.WriteByte((byte) this.charactersSlots);
      if (this.date < -9.00719925474099E+15 || this.date > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.date + ") on element date.");
      writer.WriteDouble(this.date);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.isMonoAccount = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.isSelectable = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of GameServerInformations.id.");
      this.type = (int) reader.ReadByte();
      this.status = (uint) reader.ReadByte();
      if (this.status < 0U)
        throw new Exception("Forbidden value (" + (object) this.status + ") on element of GameServerInformations.status.");
      this.completion = (uint) reader.ReadByte();
      if (this.completion < 0U)
        throw new Exception("Forbidden value (" + (object) this.completion + ") on element of GameServerInformations.completion.");
      this.charactersCount = (uint) reader.ReadByte();
      if (this.charactersCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.charactersCount + ") on element of GameServerInformations.charactersCount.");
      this.charactersSlots = (uint) reader.ReadByte();
      if (this.charactersSlots < 0U)
        throw new Exception("Forbidden value (" + (object) this.charactersSlots + ") on element of GameServerInformations.charactersSlots.");
      this.date = reader.ReadDouble();
      if (this.date < -9.00719925474099E+15 || this.date > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.date + ") on element of GameServerInformations.date.");
    }
  }
}
