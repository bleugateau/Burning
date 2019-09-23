using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ConsoleCommandsListMessage : NetworkMessage
  {
    public List<string> aliases = new List<string>();
    public List<string> args = new List<string>();
    public List<string> descriptions = new List<string>();
    public const uint Id = 6127;

    public override uint MessageId
    {
      get
      {
        return 6127;
      }
    }

    public ConsoleCommandsListMessage()
    {
    }

    public ConsoleCommandsListMessage(
      List<string> aliases,
      List<string> args,
      List<string> descriptions)
    {
      this.aliases = aliases;
      this.args = args;
      this.descriptions = descriptions;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.aliases.Count);
      for (int index = 0; index < this.aliases.Count; ++index)
        writer.WriteUTF(this.aliases[index]);
      writer.WriteShort((short) this.args.Count);
      for (int index = 0; index < this.args.Count; ++index)
        writer.WriteUTF(this.args[index]);
      writer.WriteShort((short) this.descriptions.Count);
      for (int index = 0; index < this.descriptions.Count; ++index)
        writer.WriteUTF(this.descriptions[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
        this.aliases.Add(reader.ReadUTF());
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
        this.args.Add(reader.ReadUTF());
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
        this.descriptions.Add(reader.ReadUTF());
    }
  }
}
