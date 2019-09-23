using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaInvitationCandidatesAnswer : NetworkMessage
  {
    public List<LeagueFriendInformations> candidates = new List<LeagueFriendInformations>();
    public const uint Id = 6783;

    public override uint MessageId
    {
      get
      {
        return 6783;
      }
    }

    public GameRolePlayArenaInvitationCandidatesAnswer()
    {
    }

    public GameRolePlayArenaInvitationCandidatesAnswer(List<LeagueFriendInformations> candidates)
    {
      this.candidates = candidates;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.candidates.Count);
      for (int index = 0; index < this.candidates.Count; ++index)
        this.candidates[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        LeagueFriendInformations friendInformations = new LeagueFriendInformations();
        friendInformations.Deserialize(reader);
        this.candidates.Add(friendInformations);
      }
    }
  }
}
