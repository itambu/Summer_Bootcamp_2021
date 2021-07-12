namespace ConsoleAppTask1.Services
{
    public class EncryptionService
    {
        private const int CryptNumber = 26;

        public string Decrypt(string message, int key)
        {
            return Encrypt(message, CryptNumber - key);
        }
        public string Encrypt(string message, int key)
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
            return (char)((((value + key) - offset) % CryptNumber) + offset);
        }
    }
}
