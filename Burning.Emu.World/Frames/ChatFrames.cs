using Burning.Common.Entity;
using Burning.Common.Managers.Frame;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Game.Command;
using Burning.Emu.World.Game.World;

namespace Burning.Emu.World.Frames
{
    public class ChatFrames : Frame
    {
        //ChatClientMultiMessage
        [PacketId(ChatClientMultiMessage.Id)]
        public void ChatClientMultiMessageFrame(WorldClient client, ChatClientMultiMessage chatClientMultiMessage)
        {
            if (chatClientMultiMessage.content.StartsWith("."))
            {
                CommandManager.GetCommandeFromContent(chatClientMultiMessage.content, client);
            }
            else
            {

                switch((ChatChannelsMultiEnum)chatClientMultiMessage.channel)
                {
                    case ChatChannelsMultiEnum.CHANNEL_GLOBAL:

                        foreach(var othersClients in WorldManager.Instance.GetNearestClientsFromCharacter(client.ActiveCharacter))
                            othersClients.SendPacket(new ChatServerMessage((uint)ChatChannelsMultiEnum.CHANNEL_GLOBAL, chatClientMultiMessage.content, 0, client.ActiveCharacter.Name, client.ActiveCharacter.Id, client.ActiveCharacter.Name, "", (uint)client.Account.Id));

                        client.SendPacket(new ChatServerMessage((uint)ChatChannelsMultiEnum.CHANNEL_GLOBAL, chatClientMultiMessage.content, 0, client.ActiveCharacter.Name, client.ActiveCharacter.Id, client.ActiveCharacter.Name, "", (uint)client.Account.Id));
                        break;
                    case ChatChannelsMultiEnum.CHANNEL_GUILD:
                        if (client.ActiveCharacter.Guild != null)
                        {
                            foreach(var othersClient in WorldManager.Instance.worldClients.FindAll(x => x.ActiveCharacter != null && x.ActiveCharacter.Id != client.ActiveCharacter.Id && x.ActiveCharacter.Guild.Id == client.ActiveCharacter.Guild.Id))
                                othersClient.SendPacket(new ChatServerMessage((uint)ChatChannelsMultiEnum.CHANNEL_GUILD, chatClientMultiMessage.content, 0, client.ActiveCharacter.Name, client.ActiveCharacter.Id, client.ActiveCharacter.Name, "", (uint)client.Account.Id));

                            client.SendPacket(new ChatServerMessage((uint)ChatChannelsMultiEnum.CHANNEL_GUILD, chatClientMultiMessage.content, 0, client.ActiveCharacter.Name, client.ActiveCharacter.Id, client.ActiveCharacter.Name, "", (uint)client.Account.Id));
                        }
                        else
                            client.SendPacket(new ChatErrorMessage((uint)ChatErrorEnum.CHAT_ERROR_NO_GUILD));
                        break;
                }
            }
            
        }
    }
}
