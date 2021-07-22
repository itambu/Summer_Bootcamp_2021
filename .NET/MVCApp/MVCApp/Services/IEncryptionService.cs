using MVCApp.CoreModels;

namespace MVCApp.Services
{
    public interface IEncryptionService
    {

        Message Encrypt(Message message, int key);

        Message Decrypt(Message message, int key);

        string GetHash(string password);

    }
}
