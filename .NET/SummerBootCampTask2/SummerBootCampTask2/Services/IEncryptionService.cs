using SummerBootCampTask2.CoreModels;

namespace SummerBootCampTask2.Services
{
    public interface IEncryptionService
    {
        void Encrypt(Message message, int key);

        Message Decrypt(Message message, int key);
    }
}
