using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachInvitationOfferMessage : NetworkMessage
  {
    public const uint Id = 6805;
    public CharacterMinimalInformations host;
    public uint timeLeftBeforeCancel;

    public override uint MessageId
    {
      get
      {
        return 6805;
      }
    }

    public BreachInvitationOfferMessage()
    {
    }

    public BreachInvitationOfferMessage(
      CharacterMinimalInformations host,
      uint timeLeftBeforeCancel)
    {
      this.host = host;
      this.timeLeftBeforeCancel = timeLeftBeforeCancel;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.host.Serialize(writer);
      if (this.timeLeftBeforeCancel < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeLeftBeforeCancel + ") on element timeLeftBeforeCancel.");
      writer.WriteVarInt((int) this.timeLeftBeforeCancel);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.host = new CharacterMinimalInformations();
      this.host.Deserialize(reader);
      this.timeLeftBeforeCancel = reader.ReadVarUhInt();
      if (this.timeLeftBeforeCancel < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeLeftBeforeCancel + ") on element of BreachInvitationOfferMessage.timeLeftBeforeCancel.");
    }
  }
}
