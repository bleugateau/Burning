using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AcquaintanceAddedMessage : NetworkMessage
  {
    public const uint Id = 6818;
    public AcquaintanceInformation acquaintanceAdded;

    public override uint MessageId
    {
      get
      {
        return 6818;
      }
    }

    public AcquaintanceAddedMessage()
    {
    }

    public AcquaintanceAddedMessage(AcquaintanceInformation acquaintanceAdded)
    {
      this.acquaintanceAdded = acquaintanceAdded;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.acquaintanceAdded.TypeId);
      this.acquaintanceAdded.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.acquaintanceAdded = ProtocolTypeManager.GetInstance<AcquaintanceInformation>((uint) reader.ReadUShort());
      this.acquaintanceAdded.Deserialize(reader);
    }
  }
}
