using designPatterns.Domain.Entities;

namespace designPatterns.Domain.Services
{
    public interface IUserSessionFactory
    {
        UserLoginSession Create(User executor);
    }
}