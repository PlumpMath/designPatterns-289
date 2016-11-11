using System;
using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.StrategyPattern
{
    public class ShellSort : SortStrategy
    {
        public override string Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            return "ShellSorted list ";
        }
    }
}