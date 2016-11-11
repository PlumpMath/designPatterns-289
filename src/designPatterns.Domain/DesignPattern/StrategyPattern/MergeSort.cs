using System;
using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.StrategyPattern
{
    public class MergeSort : SortStrategy
    {
        public override string Sort(List<string> list)
        {
            return "MergeSorted list ";
        }
    }
}