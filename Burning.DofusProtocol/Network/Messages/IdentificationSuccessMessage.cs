using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdentificationSuccessMessage : NetworkMessage
  {
    public const uint Id = 22;
    public string login;
    public string nickname;
    public uint accountId;
    public uint communityId;
    public bool hasRights;
    public string secretQuestion;
    public double accountCreation;
    public double subscriptionElapsedDuration;
    public double subscriptionEndDate;
    public bool wasAlreadyConnected;
    public uint havenbagAvailableRoom;

    public override uint MessageId
    {
      get
      {
        return 22;
      }
    }

    public IdentificationSuccessMessage()
    {
    }

    public IdentificationSuccessMessage(
      string login,
      string nickname,
      uint accountId,
      uint communityId,
      bool hasRights,
      string secretQuestion,
      double accountCreation,
      double subscriptionElapsedDuration,
      double subscriptionEndDate,
      bool wasAlreadyConnected,
      uint havenbagAvailableRoom)
    {
      this.login = login;
      this.nickname = nickname;
      this.accountId = accountId;
      this.communityId = communityId;
      this.hasRights = hasRights;
      this.secretQuestion = secretQuestion;
      this.accountCreation = accountCreation;
      this.subscriptionElapsedDuration = subscriptionElapsedDuration;
      this.subscriptionEndDate = subscriptionEndDate;
      this.wasAlreadyConnected = wasAlreadyConnected;
      this.havenbagAvailableRoom = havenbagAvailableRoom;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.hasRights), (byte) 1, this.wasAlreadyConnected);
      writer.WriteByte((byte) num);
      writer.WriteUTF(this.login);
      writer.WriteUTF(this.nickname);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      if (this.communityId < 0U)
        throw new Exception("Forbidden value (" + (object) this.communityId + ") on element communityId.");
      writer.WriteByte((byte) this.communityId);
      writer.WriteUTF(this.secretQuestion);
      if (this.accountCreation < 0.0 || this.accountCreation > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.accountCreation + ") on element accountCreation.");
      writer.WriteDouble(this.accountCreation);
      if (this.subscriptionElapsedDuration < 0.0 || this.subscriptionElapsedDuration > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionElapsedDuration + ") on element subscriptionElapsedDuration.");
      writer.WriteDouble(this.subscriptionElapsedDuration);
      if (this.subscriptionEndDate < 0.0 || this.subscriptionEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionEndDate + ") on element subscriptionEndDate.");
      writer.WriteDouble(this.subscriptionEndDate);
      if (this.havenbagAvailableRoom < 0U || this.havenbagAvailableRoom > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.havenbagAvailableRoom + ") on element havenbagAvailableRoom.");
      writer.WriteByte((byte) this.havenbagAvailableRoom);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.hasRights = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.wasAlreadyConnected = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.login = reader.ReadUTF();
      this.nickname = reader.ReadUTF();
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of IdentificationSuccessMessage.accountId.");
      this.communityId = (uint) reader.ReadByte();
      if (this.communityId < 0U)
        throw new Exception("Forbidden value (" + (object) this.communityId + ") on element of IdentificationSuccessMessage.communityId.");
      this.secretQuestion = reader.ReadUTF();
      this.accountCreation = reader.ReadDouble();
      if (this.accountCreation < 0.0 || this.accountCreation > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.accountCreation + ") on element of IdentificationSuccessMessage.accountCreation.");
      this.subscriptionElapsedDuration = reader.ReadDouble();
      if (this.subscriptionElapsedDuration < 0.0 || this.subscriptionElapsedDuration > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionElapsedDuration + ") on element of IdentificationSuccessMessage.subscriptionElapsedDuration.");
      this.subscriptionEndDate = reader.ReadDouble();
      if (this.subscriptionEndDate < 0.0 || this.subscriptionEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionEndDate + ") on element of IdentificationSuccessMessage.subscriptionEndDate.");
      this.havenbagAvailableRoom = (uint) reader.ReadByte();
      if (this.havenbagAvailableRoom < 0U || this.havenbagAvailableRoom > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.havenbagAvailableRoom + ") on element of IdentificationSuccessMessage.havenbagAvailableRoom.");
    }
  }
}
