namespace designPatterns.Domain.DesignPattern.IteratorPattern
{
    public interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }
}