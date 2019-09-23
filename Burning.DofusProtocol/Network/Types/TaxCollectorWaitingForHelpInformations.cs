using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
  {
    public new const uint Id = 447;
    public ProtectedEntityWaitingForHelpInfo waitingForHelpInfo;

    public override uint TypeId
    {
      get
      {
        return 447;
      }
    }

    public TaxCollectorWaitingForHelpInformations()
    {
    }

    public TaxCollectorWaitingForHelpInformations(
      ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
    {
      this.waitingForHelpInfo = waitingForHelpInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.waitingForHelpInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
      this.waitingForHelpInfo.Deserialize(reader);
    }
  }
}
