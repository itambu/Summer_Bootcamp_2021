using ConsoleAppTask1.Menu;
using ConsoleAppTask1.Services;

namespace ConsoleAppTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptionService = new EncryptionService();
            var serializationService = new SerializationService();
            var provider = new ConsoleProvider(encryptionService, serializationService);
            while (true)
            {
                provider.ShowMenu();
                var input = provider.GetInput(1, 3);

                switch (input)
                {
                    case (int)MenuItem.GetMessages:
                        var key = provider.GetKey();
                        provider.ShowUserMessages(key);
                        break;
                    case (int)MenuItem.WriteMessage:
                        key = provider.GetKey();
                        var message = provider.GetInput("Введите сообщение:");
                        var encryptedMessage = encryptionService.Encrypt(message, key);
                        serializationService.SaveMessage(encryptedMessage);
                        provider.ShowMessage("Сообщение сохранено!");
                        break;
                    case (int)MenuItem.ChangeFilePath:
                        var filePath = provider.GetInput("Введите новый путь файла:");
                        serializationService.FilePath = filePath;
                        provider.ShowMessage("Обновлено!");
                        break;
                }
            }
        }
    }
}
