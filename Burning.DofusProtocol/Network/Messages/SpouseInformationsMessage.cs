using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SpouseInformationsMessage : NetworkMessage
  {
    public const uint Id = 6356;
    public FriendSpouseInformations spouse;

    public override uint MessageId
    {
      get
      {
        return 6356;
      }
    }

    public SpouseInformationsMessage()
    {
    }

    public SpouseInformationsMessage(FriendSpouseInformations spouse)
    {
      this.spouse = spouse;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.spouse.TypeId);
      this.spouse.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spouse = ProtocolTypeManager.GetInstance<FriendSpouseInformations>((uint) reader.ReadUShort());
      this.spouse.Deserialize(reader);
    }
  }
}
