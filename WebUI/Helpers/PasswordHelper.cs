using System;
using System.Security.Cryptography;
using System.Text;

namespace WebUI.Helpers
{
    public sealed class PasswordHelper
    {
        public static string GetPasswordHash(string password)
        {
            dynamic provider = new MD5CryptoServiceProvider();
            byte[] hashBin = provider.ComputeHash(Encoding.Default.GetBytes(password));
            string passwordHash = BitConverter.ToString(hashBin).Replace("-", string.Empty).ToLower();

            return passwordHash;
        }
    }
}