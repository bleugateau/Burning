using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachBranchesMessage : NetworkMessage
  {
    public List<ExtendedBreachBranch> branches = new List<ExtendedBreachBranch>();
    public const uint Id = 6812;

    public override uint MessageId
    {
      get
      {
        return 6812;
      }
    }

    public BreachBranchesMessage()
    {
    }

    public BreachBranchesMessage(List<ExtendedBreachBranch> branches)
    {
      this.branches = branches;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.branches.Count);
      for (int index = 0; index < this.branches.Count; ++index)
        this.branches[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ExtendedBreachBranch extendedBreachBranch = new ExtendedBreachBranch();
        extendedBreachBranch.Deserialize(reader);
        this.branches.Add(extendedBreachBranch);
      }
    }
  }
}
