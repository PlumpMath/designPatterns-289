using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.MediatorPattern
{
    public class Chatroom : AbstractChatroom
    {
        private readonly Dictionary<string, Participant> _participants =
            new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override string Send(
            string from, string to, string message)
        {
            var participant = _participants[to];

            return participant != null ? participant.Receive(@from, message) : "";
        }
    }
}