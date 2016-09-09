using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AcklenAvenue.Commands;
using designPatterns.Domain.Application.Commands;
using designPatterns.Domain.DomainEvents;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Services;


namespace designPatterns.Domain.Application.CommandHandlers
{
    public class UserEmailCreator : ICommandHandler<CreateEmailLoginUser>
    {
        readonly IWriteableRepository _writeableRepository;
        private readonly IReadOnlyRepository _readOnlyRepository;

        public UserEmailCreator(IWriteableRepository writeableRepository, IReadOnlyRepository readOnlyRepository)
        {
            _writeableRepository = writeableRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        #region ICommandHandler Members

        public void Handle(IUserSession userIssuingCommand, CreateEmailLoginUser command)
        {
            var userCreated = new UserEmailLogin(command.Name, command.Email, command.EncryptedPassword,
                command.PhoneNumber);

            command.abilities.ToList().ForEach(x => userCreated.AddAbility(_readOnlyRepository.GetById<UserAbility>(x.Id)));

            var userSaved = _writeableRepository.Create(userCreated);

            NotifyObservers(new UserEmailCreated(userSaved.Id, command.Email, command.Name, command.PhoneNumber));
        }

        public event DomainEvent NotifyObservers;

        #endregion
    }
}