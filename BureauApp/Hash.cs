using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BureauApp
{
    class Hash
    {
        public static string GetHash(string str)
        {
            byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            bool upperCase = false;

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2": "x2"));

            return result.ToString();
        }
    }
}
