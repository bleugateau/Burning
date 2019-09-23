using Burning.Common.Entity;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Command.Commands
{
    public class ReloadCommand : Command
    {
        public string Content { get; set; }

        public WorldClient Client { get; set; }

        public string Type { get; set; }

        [CommandAttribute("reload")]
        public ReloadCommand(string content, WorldClient client)
        {
            this.Content = content;
            this.Client = client;
        }

        public override void RunCommand()
        {
            if (this.Content != null)
            {
                string arg = this.Content.Split(' ').FirstOrDefault(x => x.Contains("-"));
                this.Type = arg != null ? arg.Replace("-", "") : arg;
            }

            //todo
            switch (this.Type)
            {
                case "npcs":
                    MapManager.Instance.GetMap(this.Client.ActiveCharacter.MapId).ReloadNpc();
                    this.Client.SendPacket(new ChatServerMessage(10, "<b>npcs</b> has been reloaded.", 0, "", 0, "", "", 0));
                    break;
                case "mobs":
                    //MapManager.Instance.GetMap(this.Client.ActiveCharacter.MapId).ReloadNpc();
                    this.Client.SendPacket(new ChatServerMessage(10, "<b>mobs</b> has been reloaded.", 0, "", 0, "", "", 0));
                    break;
                default:
                    this.Client.SendPacket(new ChatServerMessage(10, "<b>reload</b> please choose arg (-npcs, -mobs).", 0, "", 0, "", "", 0));
                    return;
            }

            this.ReloadMap();
        }

        private void ReloadMap()
        {
            this.Client.SendPacket(new GameContextDestroyMessage());
            this.Client.SendPacket(new GameContextCreateMessage(1));

            this.Client.SendPacket(new CurrentMapMessage(this.Client.ActiveCharacter.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));
        }
    }
}
