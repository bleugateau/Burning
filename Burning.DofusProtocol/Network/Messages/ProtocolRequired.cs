using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ProtocolRequired : NetworkMessage
  {
    public const uint Id = 1;
    public uint requiredVersion;
    public uint currentVersion;

    public override uint MessageId
    {
      get
      {
        return 1;
      }
    }

    public ProtocolRequired()
    {
    }

    public ProtocolRequired(uint requiredVersion, uint currentVersion)
    {
      this.requiredVersion = requiredVersion;
      this.currentVersion = currentVersion;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.requiredVersion < 0U)
        throw new Exception("Forbidden value (" + (object) this.requiredVersion + ") on element requiredVersion.");
      writer.WriteInt((int) this.requiredVersion);
      if (this.currentVersion < 0U)
        throw new Exception("Forbidden value (" + (object) this.currentVersion + ") on element currentVersion.");
      writer.WriteInt((int) this.currentVersion);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.requiredVersion = (uint) reader.ReadInt();
      if (this.requiredVersion < 0U)
        throw new Exception("Forbidden value (" + (object) this.requiredVersion + ") on element of ProtocolRequired.requiredVersion.");
      this.currentVersion = (uint) reader.ReadInt();
      if (this.currentVersion < 0U)
        throw new Exception("Forbidden value (" + (object) this.currentVersion + ") on element of ProtocolRequired.currentVersion.");
    }
  }
}
