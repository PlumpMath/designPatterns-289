﻿using BlingBag;
using designPatterns.Domain;
using designPatterns.Domain.DomainEvents;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Services;

namespace designPatterns.Web.Api
{
    public class PasswordResetEmailSender : IBlingHandler<PasswordResetTokenCreated>
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IEmailSender _emailSender;
        readonly IBaseUrlProvider _baseUrlProvider;

        public PasswordResetEmailSender(IReadOnlyRepository readOnlyRepository, IEmailSender emailSender, IBaseUrlProvider baseUrlProvider)
        {
            _readOnlyRepository = readOnlyRepository;
            _emailSender = emailSender;
            _baseUrlProvider = baseUrlProvider;
        }

        public void Handle(PasswordResetTokenCreated @event)
        {
            var user = _readOnlyRepository.GetById<UserEmailLogin>(@event.UserId);
            _emailSender.Send(user.Email, new PasswordResetEmail(_baseUrlProvider.GetBaseUrl(), @event.TokenId));
        }
    }
}