using AcklenAvenue.Commands;
using designPatterns.Domain.Application.Commands;
using designPatterns.Domain.DomainEvents;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Services;

namespace designPatterns.Domain.Application.CommandHandlers
{
    public class UserProfileUpdater : ICommandHandler<UpdateUserProfile>
    {
        readonly IReadOnlyRepository _readonlyRepo;

        public UserProfileUpdater(IReadOnlyRepository readonlyRepo)
        {
            _readonlyRepo = readonlyRepo;
        }

        public void Handle(IUserSession userIssuingCommand, UpdateUserProfile command)
        {
            var user = _readonlyRepo.GetById<User>(command.Id);
            user.ChangeName(command.Name);
            user.ChangeEmailAddress(command.Email);
            NotifyObservers(new UserProfileUpdated(user.Id, command.Name, command.Email));
        }

        public event DomainEvent NotifyObservers;
    }
}