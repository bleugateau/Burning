using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class Account : AbstractEntity
    {
        public string Login { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string FlashKey { get; set; }
        public string Ticket { get; set; }
        public bool IsBanned { get; set; }

        public Account()
        {

        }
    }
}
