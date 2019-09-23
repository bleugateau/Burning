using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
  {
    public new const uint Id = 21;
    public Version requiredVersion;

    public override uint MessageId
    {
      get
      {
        return 21;
      }
    }

    public IdentificationFailedForBadVersionMessage()
    {
    }

    public IdentificationFailedForBadVersionMessage(uint reason, Version requiredVersion)
      : base(reason)
    {
      this.requiredVersion = requiredVersion;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.requiredVersion.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.requiredVersion = new Version();
      this.requiredVersion.Deserialize(reader);
    }
  }
}
