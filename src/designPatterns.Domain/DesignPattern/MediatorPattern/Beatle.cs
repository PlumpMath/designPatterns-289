using System;

namespace designPatterns.Domain.DesignPattern.MediatorPattern
{
    public class Beatle : Participant
    {
        public Beatle(string name)
            : base(name)
        {
        }

        public override string Receive(string from, string message)
        {
            return "To a Beatle: " + base.Receive(from, message);
        }
    }
}