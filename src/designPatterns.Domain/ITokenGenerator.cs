namespace designPatterns.Domain
{
    public interface ITokenGenerator<out T>
    {
        T Generate();
    }
}