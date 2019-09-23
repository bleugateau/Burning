using Burning.Common.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Burning.Common.Utility.Authentication
{
    public static class AuthenticationUtils
    {
        private static Random random = new Random();
        public static string GenerateTicket()
        {
            const string chars = "azertyuiopqsdfghjklmwxcvbnABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 64)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static List<int> EncodeTicket(string ticket)
        {
            List<int> ticketEncoded = new List<int>();
            byte[] test = Encoding.UTF8.GetBytes(ticket);
            foreach (var line in test)
            {
                ticketEncoded.Add((int)line);
            }

            return ticketEncoded;
        }

        public static string DecodeTicket(string encodedTicket)
        {
            string[] splitString = encodedTicket.Split(',');
            byte[] ticketToByteArray = new byte[splitString.Length];

            int[] test = new int[splitString.Length];

            for (int i = 0; i < splitString.Length; i++)
            {
                test[i] = int.Parse(splitString[i]);
                ticketToByteArray[i] = (byte)test[i];
            }

            return Encoding.UTF8.GetString(ticketToByteArray);
        }

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string GetMD5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2", CultureInfo.CurrentCulture));
            }

            return sBuilder.ToString();
        }


        //com.ankamagames.dofus.logic.connection.managers.AuthenticationManager
        public static string cipherString(Account account)
        {
            return GetMD5Hash(account.Password + account.Ticket);
        }
    }
}
