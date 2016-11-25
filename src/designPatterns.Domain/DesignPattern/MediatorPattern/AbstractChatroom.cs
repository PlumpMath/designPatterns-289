namespace designPatterns.Domain.DesignPattern.MediatorPattern
{
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract string Send(
            string from, string to, string message);
    }
}