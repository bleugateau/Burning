using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IgnoredAddedMessage : NetworkMessage
  {
    public const uint Id = 5678;
    public IgnoredInformations ignoreAdded;
    public bool session;

    public override uint MessageId
    {
      get
      {
        return 5678;
      }
    }

    public IgnoredAddedMessage()
    {
    }

    public IgnoredAddedMessage(IgnoredInformations ignoreAdded, bool session)
    {
      this.ignoreAdded = ignoreAdded;
      this.session = session;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.ignoreAdded.TypeId);
      this.ignoreAdded.Serialize(writer);
      writer.WriteBoolean(this.session);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.ignoreAdded = ProtocolTypeManager.GetInstance<IgnoredInformations>((uint) reader.ReadUShort());
      this.ignoreAdded.Deserialize(reader);
      this.session = reader.ReadBoolean();
    }
  }
}
