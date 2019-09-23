using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class TreasureHuntStepFight : TreasureHuntStep
  {
    public new const uint Id = 462;

    public override uint TypeId
    {
      get
      {
        return 462;
      }
    }

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
  }
}
