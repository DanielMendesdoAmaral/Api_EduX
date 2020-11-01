using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Utils
{
    public static class Criptografia
    {
        public static string Criptografar(string Txt, string Salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Txt + Salt));
 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}