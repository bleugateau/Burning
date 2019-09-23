using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class PortalInformation
  {
    public const uint Id = 466;
    public int portalId;
    public int areaId;

    public virtual uint TypeId
    {
      get
      {
        return 466;
      }
    }

    public PortalInformation()
    {
    }

    public PortalInformation(int portalId, int areaId)
    {
      this.portalId = portalId;
      this.areaId = areaId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.portalId);
      writer.WriteShort((short) this.areaId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.portalId = reader.ReadInt();
      this.areaId = (int) reader.ReadShort();
    }
  }
}
