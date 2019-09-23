using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyMemberInStandardFightMessage : AbstractPartyMemberInFightMessage
  {
    public new const uint Id = 6826;
    public MapCoordinatesExtended fightMap;

    public override uint MessageId
    {
      get
      {
        return 6826;
      }
    }

    public PartyMemberInStandardFightMessage()
    {
    }

    public PartyMemberInStandardFightMessage(
      uint partyId,
      uint reason,
      double memberId,
      uint memberAccountId,
      string memberName,
      uint fightId,
      int timeBeforeFightStart,
      MapCoordinatesExtended fightMap)
      : base(partyId, reason, memberId, memberAccountId, memberName, fightId, timeBeforeFightStart)
    {
      this.fightMap = fightMap;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.fightMap.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.fightMap = new MapCoordinatesExtended();
      this.fightMap.Deserialize(reader);
    }
  }
}
