﻿using System;
using AcklenAvenue.Commands;
using designPatterns.Domain.Application.Commands;
using designPatterns.Domain.DomainEvents;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Services;


namespace designPatterns.Domain.Application.CommandHandlers
{
    public class PasswordResetTokenCreator : ICommandHandler<CreatePasswordResetToken>
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly ITimeProvider _timeProvider;
        readonly IIdentityGenerator<Guid> _idGenerator;
        readonly IWriteableRepository _writeableRepository;

        public PasswordResetTokenCreator(IWriteableRepository writeableRepository, IReadOnlyRepository readOnlyRepository, ITimeProvider timeProvider, IIdentityGenerator<Guid> idGenerator)
        {
            _writeableRepository = writeableRepository;
            _readOnlyRepository = readOnlyRepository;
            _timeProvider = timeProvider;
            _idGenerator = idGenerator;
        }

        public void Handle(IUserSession userIssuingCommand, CreatePasswordResetToken command)
        {
            var user = _readOnlyRepository.First<UserEmailLogin>(x => x.Email == command.Email);
            Guid tokenId = _idGenerator.Generate();
            _writeableRepository.Create(new PasswordResetAuthorization(tokenId, user.Id, _timeProvider.Now()));
            NotifyObservers(new PasswordResetTokenCreated(tokenId, user.Id));
        }

        public event DomainEvent NotifyObservers;
    }
}