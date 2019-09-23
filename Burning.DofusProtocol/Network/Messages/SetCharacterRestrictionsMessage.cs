using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SetCharacterRestrictionsMessage : NetworkMessage
  {
    public const uint Id = 170;
    public double actorId;
    public ActorRestrictionsInformations restrictions;

    public override uint MessageId
    {
      get
      {
        return 170;
      }
    }

    public SetCharacterRestrictionsMessage()
    {
    }

    public SetCharacterRestrictionsMessage(
      double actorId,
      ActorRestrictionsInformations restrictions)
    {
      this.actorId = actorId;
      this.restrictions = restrictions;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.actorId < -9.00719925474099E+15 || this.actorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.actorId + ") on element actorId.");
      writer.WriteDouble(this.actorId);
      this.restrictions.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.actorId = reader.ReadDouble();
      if (this.actorId < -9.00719925474099E+15 || this.actorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.actorId + ") on element of SetCharacterRestrictionsMessage.actorId.");
      this.restrictions = new ActorRestrictionsInformations();
      this.restrictions.Deserialize(reader);
    }
  }
}
