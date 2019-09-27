using Burning.Common.Repository;
using Burning.DofusProtocol.Network.Messages;
using Burning.Emu.World.Network;
using Burning.Emu.World.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Command.Commands
{
    public class ItemCommand : Command
    {

        public string Content { get; set; }

        public WorldClient Client { get; set; }

        public string Type { get; set; }

        [CommandAttribute("item")]
        public ItemCommand(string content, WorldClient client)
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
                case "add":
                    try
                    {
                        int itemId = int.Parse(this.Content.Split(' ')[2]);

                        var inventory = Client.ActiveCharacter.Inventory;

                        var generatedItem = InventoryRepository.Instance.GenerateItemFromId(itemId);
                        inventory.ObjectItems.Add(generatedItem);
                        InventoryRepository.Instance.Update(inventory);

                        this.Client.SendPacket(new ObjectAddedMessage(generatedItem, 1));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("[ERROR]: {0}.", ex.Message);
                        this.Client.SendPacket(new ChatServerMessage(10, "<b>item</b> please choose arg (-add ItemId).", 0, "", 0, "", "", 0));
                    }
                    break;
                default:
                    this.Client.SendPacket(new ChatServerMessage(10, "<b>item</b> please choose arg (-add ItemId).", 0, "", 0, "", "", 0));
                    return;
            }
        }
    }
}
