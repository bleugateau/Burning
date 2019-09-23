using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ProtectedEntityWaitingForHelpInfo
  {
    public const uint Id = 186;
    public int timeLeftBeforeFight;
    public int waitTimeForPlacement;
    public uint nbPositionForDefensors;

    public virtual uint TypeId
    {
      get
      {
        return 186;
      }
    }

    public ProtectedEntityWaitingForHelpInfo()
    {
    }

    public ProtectedEntityWaitingForHelpInfo(
      int timeLeftBeforeFight,
      int waitTimeForPlacement,
      uint nbPositionForDefensors)
    {
      this.timeLeftBeforeFight = timeLeftBeforeFight;
      this.waitTimeForPlacement = waitTimeForPlacement;
      this.nbPositionForDefensors = nbPositionForDefensors;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.timeLeftBeforeFight);
      writer.WriteInt(this.waitTimeForPlacement);
      if (this.nbPositionForDefensors < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbPositionForDefensors + ") on element nbPositionForDefensors.");
      writer.WriteByte((byte) this.nbPositionForDefensors);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.timeLeftBeforeFight = reader.ReadInt();
      this.waitTimeForPlacement = reader.ReadInt();
      this.nbPositionForDefensors = (uint) reader.ReadByte();
      if (this.nbPositionForDefensors < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbPositionForDefensors + ") on element of ProtectedEntityWaitingForHelpInfo.nbPositionForDefensors.");
    }
  }
}
