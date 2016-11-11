using System.Collections.Generic;
using System.Linq;

namespace designPatterns.Domain.DesignPattern.StrategyPattern
{
    public class SortedList
    {
        private readonly List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            _sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public string Sort()
        {
            _sortstrategy.Sort(_list);

            return _list.Aggregate("", (current, name) => current + (" " + name));
        }
    }
}
