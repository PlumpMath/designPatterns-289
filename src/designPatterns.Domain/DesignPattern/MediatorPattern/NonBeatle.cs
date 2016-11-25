using System;

namespace designPatterns.Domain.DesignPattern.MediatorPattern
{
    public class NonBeatle : Participant
    {
        // Constructor
        public NonBeatle(string name)
            : base(name)
        {
        }

        public override string Receive(string from, string message)
        {
            return "To a non-Beatle: " + base.Receive(from, message);
        }
    }
}
