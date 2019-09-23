using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdentificationMessage : NetworkMessage
  {
    public List<int> credentials = new List<int>();
    public List<uint> failedAttempts = new List<uint>();
    public const uint Id = 4;
    public VersionExtended version;
    public string lang;
    public int serverId;
    public bool autoconnect;
    public bool useCertificate;
    public bool useLoginToken;
    public double sessionOptionalSalt;

    public override uint MessageId
    {
      get
      {
        return 4;
      }
    }

    public IdentificationMessage()
    {
    }

    public IdentificationMessage(
      VersionExtended version,
      string lang,
      List<int> credentials,
      int serverId,
      bool autoconnect,
      bool useCertificate,
      bool useLoginToken,
      double sessionOptionalSalt,
      List<uint> failedAttempts)
    {
      this.version = version;
      this.lang = lang;
      this.credentials = credentials;
      this.serverId = serverId;
      this.autoconnect = autoconnect;
      this.useCertificate = useCertificate;
      this.useLoginToken = useLoginToken;
      this.sessionOptionalSalt = sessionOptionalSalt;
      this.failedAttempts = failedAttempts;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.autoconnect), (byte) 1, this.useCertificate), (byte) 2, this.useLoginToken);
      writer.WriteByte((byte) num);
      this.version.Serialize(writer);
      writer.WriteUTF(this.lang);
      writer.WriteVarInt(this.credentials.Count);
      for (int index = 0; index < this.credentials.Count; ++index)
        writer.WriteByte((byte) this.credentials[index]);
      writer.WriteShort((short) this.serverId);
      if (this.sessionOptionalSalt < -9.00719925474099E+15 || this.sessionOptionalSalt > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sessionOptionalSalt + ") on element sessionOptionalSalt.");
      writer.WriteVarLong((long) this.sessionOptionalSalt);
      writer.WriteShort((short) this.failedAttempts.Count);
      for (int index = 0; index < this.failedAttempts.Count; ++index)
      {
        if (this.failedAttempts[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.failedAttempts[index] + ") on element 9 (starting at 1) of failedAttempts.");
        writer.WriteVarShort((short) this.failedAttempts[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadByte();
      this.autoconnect = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 0);
      this.useCertificate = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 1);
      this.useLoginToken = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 2);
      this.version = new VersionExtended();
      this.version.Deserialize(reader);
      this.lang = reader.ReadUTF();
      uint num2 = (uint) reader.ReadVarInt();
      for (int index = 0; (long) index < (long) num2; ++index)
        this.credentials.Add((int) reader.ReadByte());
      this.serverId = (int) reader.ReadShort();
      this.sessionOptionalSalt = (double) reader.ReadVarLong();
      if (this.sessionOptionalSalt < -9.00719925474099E+15 || this.sessionOptionalSalt > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sessionOptionalSalt + ") on element of IdentificationMessage.sessionOptionalSalt.");
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num4 = (uint) reader.ReadVarUhShort();
        if (num4 < 0U)
          throw new Exception("Forbidden value (" + (object) num4 + ") on elements of failedAttempts.");
        this.failedAttempts.Add(num4);
      }
    }
  }
}
