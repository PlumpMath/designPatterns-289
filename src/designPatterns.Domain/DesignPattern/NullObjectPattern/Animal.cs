namespace designPatterns.Domain.DesignPattern.NullObjectPattern
{
    public abstract class Animal : IAnimal
    {
        public static readonly IAnimal Null = new NullAnimal();

        public abstract string MakeSound();
    }
}