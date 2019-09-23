using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class NamedPartyTeam
  {
    public const uint Id = 469;
    public uint teamId;
    public string partyName;

    public virtual uint TypeId
    {
      get
      {
        return 469;
      }
    }

    public NamedPartyTeam()
    {
    }

    public NamedPartyTeam(uint teamId, string partyName)
    {
      this.teamId = teamId;
      this.partyName = partyName;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.teamId);
      writer.WriteUTF(this.partyName);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.teamId = (uint) reader.ReadByte();
      if (this.teamId < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamId + ") on element of NamedPartyTeam.teamId.");
      this.partyName = reader.ReadUTF();
    }
  }
}
