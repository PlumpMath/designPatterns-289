using System;

namespace designPatterns.Domain.DesignPattern.FlyweightPattern
{
    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    public class CharacterA : Character
    {
        // Constructor
        public CharacterA()
        {
            this.symbol = 'A';
            this.height = 100;
            this.width = 120;
            this.ascent = 70;
            this.descent = 0;
        }

        public override string Display(int pointSize)
        {
            this.pointSize = pointSize;
            return this.symbol + " (pointsize " + this.pointSize + ")";
        }
    }
}