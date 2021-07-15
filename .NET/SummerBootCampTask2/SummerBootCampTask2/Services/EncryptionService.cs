using SummerBootCampTask2.CoreModels;

namespace SummerBootCampTask2.Services
{
    public class EncryptionService : IEncryptionService
    {
        public Message Decrypt(Message message, int key)
        {
            message.Data = Encrypt(message.Data, 26 - key);
            return message;
        }

        public void Encrypt(Message message, int key)
        {
            message.Data = Encrypt(message.Data, key);
        }

        private string Encrypt(string message, int key)
        {
            var result = string.Empty;

            foreach (var symbol in message)
            {
                result += GetCipher(symbol, key);
            }

            return result;
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
    }
}
