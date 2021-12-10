using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceWebsite.Application.Constants
{
    public static class Randoms
    {
        public static Random random = new Random();

        public static string RandomString (int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(c => c[random.Next(c.Length)]).ToArray());
        }
    }
}
