using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.Helper
{
    public static class CryptographyHelper
    {
        public static string SHA256(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
            byte[] byteArr = SHA256.ComputeHash(buffer);
            return BitConverter.ToString(byteArr);
        }
    }
}
