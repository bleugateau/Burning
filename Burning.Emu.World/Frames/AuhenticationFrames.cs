using Burning.Common.Managers.Frame;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.Common.Repository;
using System.Linq;
using Burning.Common.Utility.Authentication;

namespace Burning.Emu.World.Frames
{
    class AuhenticationFrames : Frame
    {
        [PacketId(AuthenticationTicketMessage.Id)]
        public void AuthenticationTicketMessageFrame(WorldClient client, AuthenticationTicketMessage authenticationTicketMessage)
        {
            string ticket = AuthenticationUtils.DecodeTicket(authenticationTicketMessage.ticket);

            //client.SendPacket(new AuthenticationTicketAcceptedMessage());
            var account = AccountRepository.GetAccountByTicket(ticket);

            if(account == null)
            {
                client.SendPacket(new AuthenticationTicketRefusedMessage());
                return;
            }

            client.Account = account;
            Console.WriteLine("'{0}' switched to world with Ticket={1}", client.Account.Login, ticket);
            client.SendPacket(new AuthenticationTicketAcceptedMessage());
            client.SendPacket(new TrustStatusMessage(true, false));
        }

        [PacketId(ReloginTokenRequestMessage.Id)]
        public void ReloginTokenRequestMessageFrame(WorldClient client, ReloginTokenRequestMessage reloginTokenRequestMessage)
        {
            client.Disconnect();
        }
    }
}
