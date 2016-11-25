using System;

namespace designPatterns.Domain.DesignPattern.MediatorPattern
{
    public class Participant
    {
        private readonly string _name;

        public Participant(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public Chatroom Chatroom { set; get; }

        public string Send(string to, string message)
        {
            return Chatroom.Send(_name, to, message);
        }

        public virtual string Receive(
            string from, string message)
        {
            return string.Format("{0} to {1}: '{2}'",
                from, Name, message);
        }
    }
}