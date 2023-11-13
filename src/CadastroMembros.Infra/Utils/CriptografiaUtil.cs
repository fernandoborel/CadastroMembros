﻿using System.Security.Cryptography;
using System.Text;

namespace CadastroMembros.Infra.Data.Utils
{
    public class CriptografiaUtil
    {
        public static string GetMD5(string valor)
        {
            var hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(valor));

            var result = string.Empty;
            foreach (var item in hash)
            {
                result += item.ToString("X2"); //hexadecimal
            }

            return result;
        }
    }
}
