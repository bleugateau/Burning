using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AllianceVersatileInformations
  {
    public const uint Id = 432;
    public uint allianceId;
    public uint nbGuilds;
    public uint nbMembers;
    public uint nbSubarea;

    public virtual uint TypeId
    {
      get
      {
        return 432;
      }
    }

    public AllianceVersatileInformations()
    {
    }

    public AllianceVersatileInformations(
      uint allianceId,
      uint nbGuilds,
      uint nbMembers,
      uint nbSubarea)
    {
      this.allianceId = allianceId;
      this.nbGuilds = nbGuilds;
      this.nbMembers = nbMembers;
      this.nbSubarea = nbSubarea;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element allianceId.");
      writer.WriteVarInt((int) this.allianceId);
      if (this.nbGuilds < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbGuilds + ") on element nbGuilds.");
      writer.WriteVarShort((short) this.nbGuilds);
      if (this.nbMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element nbMembers.");
      writer.WriteVarShort((short) this.nbMembers);
      if (this.nbSubarea < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbSubarea + ") on element nbSubarea.");
      writer.WriteVarShort((short) this.nbSubarea);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.allianceId = reader.ReadVarUhInt();
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element of AllianceVersatileInformations.allianceId.");
      this.nbGuilds = (uint) reader.ReadVarUhShort();
      if (this.nbGuilds < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbGuilds + ") on element of AllianceVersatileInformations.nbGuilds.");
      this.nbMembers = (uint) reader.ReadVarUhShort();
      if (this.nbMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element of AllianceVersatileInformations.nbMembers.");
      this.nbSubarea = (uint) reader.ReadVarUhShort();
      if (this.nbSubarea < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbSubarea + ") on element of AllianceVersatileInformations.nbSubarea.");
    }
  }
}
