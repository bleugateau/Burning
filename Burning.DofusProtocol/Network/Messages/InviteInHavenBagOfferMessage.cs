using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InviteInHavenBagOfferMessage : NetworkMessage
  {
    public const uint Id = 6643;
    public CharacterMinimalInformations hostInformations;
    public int timeLeftBeforeCancel;

    public override uint MessageId
    {
      get
      {
        return 6643;
      }
    }

    public InviteInHavenBagOfferMessage()
    {
    }

    public InviteInHavenBagOfferMessage(
      CharacterMinimalInformations hostInformations,
      int timeLeftBeforeCancel)
    {
      this.hostInformations = hostInformations;
      this.timeLeftBeforeCancel = timeLeftBeforeCancel;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.hostInformations.Serialize(writer);
      writer.WriteVarInt(this.timeLeftBeforeCancel);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.hostInformations = new CharacterMinimalInformations();
      this.hostInformations.Deserialize(reader);
      this.timeLeftBeforeCancel = reader.ReadVarInt();
    }
  }
}
