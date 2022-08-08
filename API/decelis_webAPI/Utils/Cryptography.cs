using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Utils
{
    public static class Cryptography
    {
        public static string CreateHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Compare(string passwordForm, string passwordDatabase)
        {
            return BCrypt.Net.BCrypt.Verify(passwordForm, passwordDatabase);
        }
    }
}
