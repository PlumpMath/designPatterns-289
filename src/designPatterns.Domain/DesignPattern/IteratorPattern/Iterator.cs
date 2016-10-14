namespace designPatterns.Domain.DesignPattern.IteratorPattern
{
    public class Iterator : IAbstractIterator
    {
        private readonly Collection _collection;
        private int _current;
        private int _step = 1;

        public Iterator(Collection collection)
        {
            _collection = collection;
        }

        public Item First()
        {
            _current = 0;
            return _collection[_current] as Item;
        }

        public Item Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as Item;
            return null;
        }

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public Item CurrentItem
        {
            get { return _collection[_current] as Item; }
        }

        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }
    }
}
