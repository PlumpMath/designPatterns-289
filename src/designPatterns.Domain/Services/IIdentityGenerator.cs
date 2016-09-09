namespace designPatterns.Domain.Services
{
    public interface IIdentityGenerator<out T>
    {
        T Generate();
    }
}