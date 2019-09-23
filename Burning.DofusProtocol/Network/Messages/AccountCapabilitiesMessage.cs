using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AccountCapabilitiesMessage : NetworkMessage
  {
    public const uint Id = 6216;
    public uint accountId;
    public bool tutorialAvailable;
    public uint breedsVisible;
    public uint breedsAvailable;
    public int status;
    public bool canCreateNewCharacter;
    public double unlimitedRestatEndDate;

    public override uint MessageId
    {
      get
      {
        return 6216;
      }
    }

    public AccountCapabilitiesMessage()
    {
    }

    public AccountCapabilitiesMessage(
      uint accountId,
      bool tutorialAvailable,
      uint breedsVisible,
      uint breedsAvailable,
      int status,
      bool canCreateNewCharacter,
      double unlimitedRestatEndDate)
    {
      this.accountId = accountId;
      this.tutorialAvailable = tutorialAvailable;
      this.breedsVisible = breedsVisible;
      this.breedsAvailable = breedsAvailable;
      this.status = status;
      this.canCreateNewCharacter = canCreateNewCharacter;
      this.unlimitedRestatEndDate = unlimitedRestatEndDate;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.tutorialAvailable), (byte) 1, this.canCreateNewCharacter);
      writer.WriteByte((byte) num);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      if (this.breedsVisible < 0U)
        throw new Exception("Forbidden value (" + (object) this.breedsVisible + ") on element breedsVisible.");
      writer.WriteVarInt((int) this.breedsVisible);
      if (this.breedsAvailable < 0U)
        throw new Exception("Forbidden value (" + (object) this.breedsAvailable + ") on element breedsAvailable.");
      writer.WriteVarInt((int) this.breedsAvailable);
      writer.WriteByte((byte) this.status);
      if (this.unlimitedRestatEndDate < 0.0 || this.unlimitedRestatEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.unlimitedRestatEndDate + ") on element unlimitedRestatEndDate.");
      writer.WriteDouble(this.unlimitedRestatEndDate);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.tutorialAvailable = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.canCreateNewCharacter = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of AccountCapabilitiesMessage.accountId.");
      this.breedsVisible = reader.ReadVarUhInt();
      if (this.breedsVisible < 0U)
        throw new Exception("Forbidden value (" + (object) this.breedsVisible + ") on element of AccountCapabilitiesMessage.breedsVisible.");
      this.breedsAvailable = reader.ReadVarUhInt();
      if (this.breedsAvailable < 0U)
        throw new Exception("Forbidden value (" + (object) this.breedsAvailable + ") on element of AccountCapabilitiesMessage.breedsAvailable.");
      this.status = (int) reader.ReadByte();
      this.unlimitedRestatEndDate = reader.ReadDouble();
      if (this.unlimitedRestatEndDate < 0.0 || this.unlimitedRestatEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.unlimitedRestatEndDate + ") on element of AccountCapabilitiesMessage.unlimitedRestatEndDate.");
    }
  }
}
