using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
  {
    public new const uint Id = 6129;
    public double firstCharacterId;
    public uint firstCharacterCurrentWeight;
    public uint firstCharacterMaxWeight;
    public double secondCharacterId;
    public uint secondCharacterCurrentWeight;
    public uint secondCharacterMaxWeight;

    public override uint MessageId
    {
      get
      {
        return 6129;
      }
    }

    public ExchangeStartedWithPodsMessage()
    {
    }

    public ExchangeStartedWithPodsMessage(
      int exchangeType,
      double firstCharacterId,
      uint firstCharacterCurrentWeight,
      uint firstCharacterMaxWeight,
      double secondCharacterId,
      uint secondCharacterCurrentWeight,
      uint secondCharacterMaxWeight)
      : base(exchangeType)
    {
      this.firstCharacterId = firstCharacterId;
      this.firstCharacterCurrentWeight = firstCharacterCurrentWeight;
      this.firstCharacterMaxWeight = firstCharacterMaxWeight;
      this.secondCharacterId = secondCharacterId;
      this.secondCharacterCurrentWeight = secondCharacterCurrentWeight;
      this.secondCharacterMaxWeight = secondCharacterMaxWeight;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.firstCharacterId < -9.00719925474099E+15 || this.firstCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.firstCharacterId + ") on element firstCharacterId.");
      writer.WriteDouble(this.firstCharacterId);
      if (this.firstCharacterCurrentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstCharacterCurrentWeight + ") on element firstCharacterCurrentWeight.");
      writer.WriteVarInt((int) this.firstCharacterCurrentWeight);
      if (this.firstCharacterMaxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstCharacterMaxWeight + ") on element firstCharacterMaxWeight.");
      writer.WriteVarInt((int) this.firstCharacterMaxWeight);
      if (this.secondCharacterId < -9.00719925474099E+15 || this.secondCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.secondCharacterId + ") on element secondCharacterId.");
      writer.WriteDouble(this.secondCharacterId);
      if (this.secondCharacterCurrentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.secondCharacterCurrentWeight + ") on element secondCharacterCurrentWeight.");
      writer.WriteVarInt((int) this.secondCharacterCurrentWeight);
      if (this.secondCharacterMaxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.secondCharacterMaxWeight + ") on element secondCharacterMaxWeight.");
      writer.WriteVarInt((int) this.secondCharacterMaxWeight);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.firstCharacterId = reader.ReadDouble();
      if (this.firstCharacterId < -9.00719925474099E+15 || this.firstCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.firstCharacterId + ") on element of ExchangeStartedWithPodsMessage.firstCharacterId.");
      this.firstCharacterCurrentWeight = reader.ReadVarUhInt();
      if (this.firstCharacterCurrentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstCharacterCurrentWeight + ") on element of ExchangeStartedWithPodsMessage.firstCharacterCurrentWeight.");
      this.firstCharacterMaxWeight = reader.ReadVarUhInt();
      if (this.firstCharacterMaxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstCharacterMaxWeight + ") on element of ExchangeStartedWithPodsMessage.firstCharacterMaxWeight.");
      this.secondCharacterId = reader.ReadDouble();
      if (this.secondCharacterId < -9.00719925474099E+15 || this.secondCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.secondCharacterId + ") on element of ExchangeStartedWithPodsMessage.secondCharacterId.");
      this.secondCharacterCurrentWeight = reader.ReadVarUhInt();
      if (this.secondCharacterCurrentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.secondCharacterCurrentWeight + ") on element of ExchangeStartedWithPodsMessage.secondCharacterCurrentWeight.");
      this.secondCharacterMaxWeight = reader.ReadVarUhInt();
      if (this.secondCharacterMaxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.secondCharacterMaxWeight + ") on element of ExchangeStartedWithPodsMessage.secondCharacterMaxWeight.");
    }
  }
}
