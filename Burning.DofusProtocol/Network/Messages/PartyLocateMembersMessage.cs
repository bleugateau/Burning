using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyLocateMembersMessage : AbstractPartyMessage
  {
    public List<PartyMemberGeoPosition> geopositions = new List<PartyMemberGeoPosition>();
    public new const uint Id = 5595;

    public override uint MessageId
    {
      get
      {
        return 5595;
      }
    }

    public PartyLocateMembersMessage()
    {
    }

    public PartyLocateMembersMessage(uint partyId, List<PartyMemberGeoPosition> geopositions)
      : base(partyId)
    {
      this.geopositions = geopositions;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.geopositions.Count);
      for (int index = 0; index < this.geopositions.Count; ++index)
        this.geopositions[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PartyMemberGeoPosition memberGeoPosition = new PartyMemberGeoPosition();
        memberGeoPosition.Deserialize(reader);
        this.geopositions.Add(memberGeoPosition);
      }
    }
  }
}
