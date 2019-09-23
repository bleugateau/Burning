using Burning.Common.Entity;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Command.Commands
{
    public class GuildCommand : Command
    {
        public string Content { get; set; }

        public WorldClient Client { get; set; }

        public string Type { get; set; }

        [CommandAttribute("guild")]
        public GuildCommand(string content, WorldClient client)
        {
            this.Content = content;
            this.Client = client;
        }

        public override void RunCommand()
        {
            this.Client.SendPacket(new GuildCreationStartedMessage());
        }
    }
}
