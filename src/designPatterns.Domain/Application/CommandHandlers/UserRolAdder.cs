using System;
using AcklenAvenue.Commands;
using designPatterns.Domain.Application.Commands;
using designPatterns.Domain.DomainEvents;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Services;

namespace designPatterns.Domain.Application.CommandHandlers
{
    public class UserRolAdder : ICommandHandler<AddRoleToUser>
    {
        private readonly IWriteableRepository _writeableRepository;
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IIdentityGenerator<Guid> _identityGenerator;

        public UserRolAdder(IWriteableRepository writeableRepository, IReadOnlyRepository readOnlyRepository, IIdentityGenerator<Guid> identityGenerator)
        {
            _writeableRepository = writeableRepository;
            _readOnlyRepository = readOnlyRepository;
            _identityGenerator = identityGenerator;
        }

        public void Handle(IUserSession userIssuingCommand, AddRoleToUser command)
        {

            var user = _readOnlyRepository.GetById<User>(command.UserId);
            var role = _readOnlyRepository.GetById<Role>(command.RolId);

            user.AddRol(role);

            _writeableRepository.Update(user);
            NotifyObservers(new UserRoleAdded(user.Id, role.Id));


        }

        public event DomainEvent NotifyObservers;
    }
}