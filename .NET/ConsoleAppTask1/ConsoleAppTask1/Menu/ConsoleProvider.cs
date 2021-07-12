using ConsoleAppTask1.Services;
using System;

namespace ConsoleAppTask1.Menu
{
    public class ConsoleProvider
    {
        private readonly EncryptionService encryptionService;
        private readonly SerializationService serializationService;

        public ConsoleProvider(EncryptionService encryptionService, SerializationService serializationService)
        {
            this.encryptionService = encryptionService;
            this.serializationService = serializationService;
        }
        public void ShowMenu()
        {
            Console.WriteLine(@"1. Отобразить сообщения.
                                2. Написать сообщение.
                                3. Изменить путь к файлу.");
        }

        public int GetInput(int minValue, int maxValue)
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result > maxValue || result < minValue)
            {
                Console.WriteLine("Некорректный ввод!");
            }

            return result;
        }

        public void ShowUserMessages(int key)
        {
            var messages = serializationService.GetMessages();

            foreach(var message in messages)
            {
                message.Data = encryptionService.Decrypt(message.Data, key);
                Console.WriteLine(message);
            }
        }

        public int GetKey()
        {
            Console.WriteLine("Введите ключ шифрования (число от 1 до 10):");
            return GetInput(1, 10);
        }

        public string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
