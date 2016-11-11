using System;
using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.StrategyPattern
{
    public class QuickSort : SortStrategy
    {
        public override string Sort(List<string> list)
        {
            list.Sort();
            return "Sort List";
        }
    }
}