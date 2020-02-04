using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLAuthorize.Web.Utils
{
    public class NesopsUtil
    {
        public static string GetRandomStringNumber(int lenght)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Range(1, lenght).Select(s => chars[random.Next(chars.Length)]).ToArray());
        }
        public static string GetRandomString(int lenght)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(1, lenght).Select(s => chars[random.Next(chars.Length)]).ToArray());
        }
    }
}
