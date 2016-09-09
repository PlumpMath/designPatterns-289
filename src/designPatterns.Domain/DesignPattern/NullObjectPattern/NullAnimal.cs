namespace designPatterns.Domain.DesignPattern.NullObjectPattern
{
    public class NullAnimal : Animal
    {
        public override string MakeSound()
        {
            return "Unknow";
        }
    }
}