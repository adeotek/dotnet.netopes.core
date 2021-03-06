﻿using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Netopes.Core.Helpers
{
    public static class CryptoHelpers
    {
        public static string GetSha256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var bytes = Encoding.UTF8.GetBytes(input);
            var hasher = new SHA256Managed();
            var hash = hasher.ComputeHash(bytes);
            return hash.Aggregate(string.Empty, (current, b) => current + $"{b:x2}");
        }
    }
}