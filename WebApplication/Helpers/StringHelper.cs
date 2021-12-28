using System;
using System.Linq;

namespace WebApplication.Helpers
{
    public static class StringHelper
    {
        public static string Random(int length = 10, bool withSpace = false)
        {
            Random random = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (withSpace) chars += " ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}