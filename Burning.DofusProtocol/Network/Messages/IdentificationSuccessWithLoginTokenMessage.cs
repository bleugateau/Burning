using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
  {
    public new const uint Id = 6209;
    public string loginToken;

    public override uint MessageId
    {
      get
      {
        return 6209;
      }
    }

    public IdentificationSuccessWithLoginTokenMessage()
    {
    }

    public IdentificationSuccessWithLoginTokenMessage(
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
      uint havenbagAvailableRoom,
      string loginToken)
      : base(login, nickname, accountId, communityId, hasRights, secretQuestion, accountCreation, subscriptionElapsedDuration, subscriptionEndDate, wasAlreadyConnected, havenbagAvailableRoom)
    {
      this.loginToken = loginToken;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.loginToken);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.loginToken = reader.ReadUTF();
    }
  }
}
