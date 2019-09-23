using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdentificationAccountForceMessage : IdentificationMessage
  {
    public new const uint Id = 6119;
    public string forcedAccountLogin;

    public override uint MessageId
    {
      get
      {
        return 6119;
      }
    }

    public IdentificationAccountForceMessage()
    {
    }

    public IdentificationAccountForceMessage(
      VersionExtended version,
      string lang,
      List<int> credentials,
      int serverId,
      bool autoconnect,
      bool useCertificate,
      bool useLoginToken,
      double sessionOptionalSalt,
      List<uint> failedAttempts,
      string forcedAccountLogin)
      : base(version, lang, credentials, serverId, autoconnect, useCertificate, useLoginToken, sessionOptionalSalt, failedAttempts)
    {
      this.forcedAccountLogin = forcedAccountLogin;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.forcedAccountLogin);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.forcedAccountLogin = reader.ReadUTF();
    }
  }
}
