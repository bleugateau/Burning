using Burning.Common.Managers.Frame;
using Burning.Emu.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FlatyBot.Common.Security;
using FlatyBot.Common.IO;
using Burning.Common.Repository;

namespace Burning.Emu.Frames
{
    public class IdentificationFrames : Frame
    {
        [PacketId(IdentificationMessage.Id)]
        public void IdentificationMessageFrame(AuthClient client, IdentificationMessage identificationMessage)
        {

            List<string> credential = identificationMessage.lang.Split('|').ToList(); //acount resolve from DI patch

            var account = AccountRepository.GetAccountByLogin(credential[0]);

            if(account == null)
            {
                client.SendPacket(new IdentificationFailedMessage((uint)IdentificationFailureReasonEnum.WRONG_CREDENTIALS));
                return;
            }

            if(credential[1] != account.Password)
            {
                client.SendPacket(new IdentificationFailedMessage((uint)IdentificationFailureReasonEnum.WRONG_CREDENTIALS));
                return;
            }

            if(account.IsBanned)
            {
                client.SendPacket(new IdentificationFailedMessage((uint)IdentificationFailureReasonEnum.BANNED));
                return;
            }

                //ici besoin de décoder le compte
            List<Burning.DofusProtocol.Network.Types.GameServerInformations> gameServerInformations = new List<Burning.DofusProtocol.Network.Types.GameServerInformations>();
            gameServerInformations.Add(new Burning.DofusProtocol.Network.Types.GameServerInformations(16, 1, true, (uint)ServerStatusEnum.ONLINE, 0, true, 1, 6, 4655.00));

            client.SendPacket(new CredentialsAcknowledgementMessage());
            client.SendPacket(new IdentificationSuccessMessage(credential[0], credential[1], 1, 1, true, "DELETE ?", 454.00, 4654.00, 54564.00, false, 0));
            client.SendPacket(new ServersListMessage(gameServerInformations, 0, true));

            client.Account = account;
            client.Account.Ticket = client.salt;
            AccountRepository.Update(client.Account);
        }
    }
}
