using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ArenaFighterLeaveMessage : NetworkMessage
  {
    public const uint Id = 6700;
    public CharacterBasicMinimalInformations leaver;

    public override uint MessageId
    {
      get
      {
        return 6700;
      }
    }

    public ArenaFighterLeaveMessage()
    {
    }

    public ArenaFighterLeaveMessage(CharacterBasicMinimalInformations leaver)
    {
      this.leaver = leaver;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.leaver.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.leaver = new CharacterBasicMinimalInformations();
      this.leaver.Deserialize(reader);
    }
  }
}
