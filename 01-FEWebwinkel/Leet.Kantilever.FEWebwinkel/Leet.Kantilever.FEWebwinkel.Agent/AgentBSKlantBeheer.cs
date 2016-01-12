using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.FEWebwinkel.Agent
{
    public class AgentBSKlantBeheer : IAgentBSKlantBeheer
    {
        public AgentBSKlantBeheer()
        {

        }

        public Klant Login(string username, string password)
        {
            if(username == "Pim" && password == sha256_hash("PimV"))
            {
                return new Klant
                {
                    ID = 1,
                    UserName = username,
                    Password = password,
                };
            }

            return null;
        }

        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
