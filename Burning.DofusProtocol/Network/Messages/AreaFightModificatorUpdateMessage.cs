using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AreaFightModificatorUpdateMessage : NetworkMessage
  {
    public const uint Id = 6493;
    public int spellPairId;

    public override uint MessageId
    {
      get
      {
        return 6493;
      }
    }

    public AreaFightModificatorUpdateMessage()
    {
    }

    public AreaFightModificatorUpdateMessage(int spellPairId)
    {
      this.spellPairId = spellPairId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.spellPairId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellPairId = reader.ReadInt();
    }
  }
}
