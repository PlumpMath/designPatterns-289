namespace designPatterns.Domain
{
    public interface IUserSessionFactory
    {
        UserSession Create(User executor);
    }
}