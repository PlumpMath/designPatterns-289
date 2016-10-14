namespace designPatterns.Domain.DesignPattern.IteratorPattern
{
    public class Item
    {
        private readonly string _name;

        public Item(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}