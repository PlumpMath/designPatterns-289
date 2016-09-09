using designPatterns.Domain.ValueObjects;

namespace designPatterns.Domain.Services
{
    public interface IPasswordEncryptor
    {
        EncryptedPassword Encrypt(string clearTextPassword);
    }
}