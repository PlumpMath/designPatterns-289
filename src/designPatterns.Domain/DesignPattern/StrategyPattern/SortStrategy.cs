using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.StrategyPattern
{
    public abstract class SortStrategy
    {
        public abstract string Sort(List<string> list);
    }
}