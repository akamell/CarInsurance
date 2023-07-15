using System;
using System.Linq;
using System.Text;
using CarInsurance.Domain.Services;
using Konscious.Security.Cryptography;

namespace CarInsurance.Infrastructure.Services
{
    public class CryptographyArgon2Service : ICryptographyService
    {
        private readonly int _deagreeOfParallelism;
        private readonly int _memorySize;
        private readonly int _iterations;

        public CryptographyArgon2Service()
        {
            _deagreeOfParallelism = 2;
            _memorySize = 8192;
            _iterations = 2;
        }

        public string GetHashPassword(string password, string salt)
        {
            var passwdBytes = Encoding.ASCII.GetBytes(password);
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            var argon2 = new Argon2i(passwdBytes);
            argon2.DegreeOfParallelism = _deagreeOfParallelism;
            argon2.MemorySize = _memorySize;
            argon2.Iterations = _iterations;
            argon2.Salt = saltBytes;
            var hash = argon2.GetBytes(128);
            var result = Convert.ToBase64String(hash);
            return result;
        }

        public string GetSalt(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
