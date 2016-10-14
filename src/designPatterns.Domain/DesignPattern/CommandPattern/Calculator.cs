using System;

namespace designPatterns.Domain.DesignPattern.CommandPattern
{
    public class Calculator
    {
        private int _curr;

        public string Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': _curr += operand; break;
                case '-': _curr -= operand; break;
                case '*': _curr *= operand; break;
                case '/': _curr /= operand; break;
            }
            return string.Format(
                "Current value = {0,3} (following {1} {2})", _curr, @operator, operand);
        }
    }
}