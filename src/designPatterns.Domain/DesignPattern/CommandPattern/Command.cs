namespace designPatterns.Domain.DesignPattern.CommandPattern
{
    public abstract class Command
    {
        public abstract string Execute();
        public abstract string UnExecute();
    }
}