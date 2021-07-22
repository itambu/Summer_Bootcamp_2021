using MVCApp.CoreModels;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MVCApp.Services
{
    public class EncryptionService : IEncryptionService
    {
        public Message Decrypt(Message message, int key)
        {
            message = Encrypt(message, 26 - key);
            return message;
        }

        public Message Encrypt(Message message, int key)
        {
            var result = string.Empty;

            foreach (var symbol in message.Data)
            {
                result += GetCipher(symbol, key);
            }

            message.Data = result;
            return message;
        }

        private static char GetCipher(char value, int key)
        {
            if (!char.IsLetter(value))
            {
                return value;
            }

            char offset = char.IsUpper(value) ? 'A' : 'a';
            return (char)((((value + key) - offset) % 26) + offset);
        }

        public string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }
    }
}
