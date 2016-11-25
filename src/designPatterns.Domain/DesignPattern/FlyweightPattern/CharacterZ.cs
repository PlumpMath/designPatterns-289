using System;

namespace designPatterns.Domain.DesignPattern.FlyweightPattern
{
    public class CharacterZ : Character
    {
        // Constructor
        public CharacterZ()
        {
            this.symbol = 'Z';
            this.height = 100;
            this.width = 100;
            this.ascent = 68;
            this.descent = 0;
        }

        public override string Display(int pointSize)
        {
            this.pointSize = pointSize;
            return this.symbol +
              " (pointsize " + this.pointSize + ")";
        }
    }
}
