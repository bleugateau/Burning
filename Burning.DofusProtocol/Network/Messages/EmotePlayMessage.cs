using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EmotePlayMessage : EmotePlayAbstractMessage
  {
    public new const uint Id = 5683;
    public double actorId;
    public uint accountId;

    public override uint MessageId
    {
      get
      {
        return 5683;
      }
    }

    public EmotePlayMessage()
    {
    }

    public EmotePlayMessage(uint emoteId, double emoteStartTime, double actorId, uint accountId)
      : base(emoteId, emoteStartTime)
    {
      this.actorId = actorId;
      this.accountId = accountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.actorId < -9.00719925474099E+15 || this.actorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.actorId + ") on element actorId.");
      writer.WriteDouble(this.actorId);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.actorId = reader.ReadDouble();
      if (this.actorId < -9.00719925474099E+15 || this.actorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.actorId + ") on element of EmotePlayMessage.actorId.");
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of EmotePlayMessage.accountId.");
    }
  }
}
