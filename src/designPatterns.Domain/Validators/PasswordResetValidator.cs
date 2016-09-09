using System;
using System.Collections.Generic;
using System.Linq;
using AcklenAvenue.Commands;
using designPatterns.Domain.Application.Commands;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Exceptions;
using designPatterns.Domain.Services;


namespace designPatterns.Domain.Validators
{
    public class PasswordResetValidator : ICommandValidator<CreatePasswordResetToken>
    {
        readonly IReadOnlyRepository _readOnlyRepsitory;

        public PasswordResetValidator(IReadOnlyRepository readOnlyRepsitory)
        {
            _readOnlyRepsitory = readOnlyRepsitory;
        }

        public void Validate(IUserSession userSession, CreatePasswordResetToken command)
        {
            var validationFailures = new List<ValidationFailure>();

            if (string.IsNullOrEmpty(command.Email))
                validationFailures.Add(new ValidationFailure("Email", ValidationFailureType.Missing));
            else
            {
                try
                {
                    _readOnlyRepsitory.First<UserEmailLogin>(x => x.Email == command.Email);
                }
                catch (ItemNotFoundException<UserEmailLogin>)
                {
                    validationFailures.Add(new ValidationFailure("Email", ValidationFailureType.DoesNotExist));
                }
            }

            if (validationFailures.Any())
                throw new CommandValidationException(validationFailures);
        }
    }
}