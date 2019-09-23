using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class TreasureHuntStepDig : TreasureHuntStep
  {
    public new const uint Id = 465;

    public override uint TypeId
    {
      get
      {
        return 465;
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
