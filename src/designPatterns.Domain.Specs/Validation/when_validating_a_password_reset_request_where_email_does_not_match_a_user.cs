using System;
using AcklenAvenue.Commands;
using AcklenAvenue.Testing.Moq;
using Machine.Specifications;
using Moq;
using designPatterns.Domain.Application.Commands;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Exceptions;
using designPatterns.Domain.Services;
using designPatterns.Domain.Validators;
using designPatterns.Domain.ValueObjects;

using It = Machine.Specifications.It;

namespace designPatterns.Domain.Specs.Validation
{
    public class when_validating_a_password_reset_request_where_email_does_not_match_a_user
    {
        const string EmailAddress = "me@test.com";
        static ICommandValidator<CreatePasswordResetToken> _validator;
        static Exception _exception;
        static IReadOnlyRepository _readOnlyRepsitory;

        Establish context =
            () =>
            {
                _readOnlyRepsitory = Mock.Of<IReadOnlyRepository>();
                _validator = new PasswordResetValidator(_readOnlyRepsitory);

                Mock.Get(_readOnlyRepsitory).Setup(x => x.First(ThatHas.AnExpressionFor<UserEmailLogin>()
                    .ThatMatches(new UserEmailLogin("some user", EmailAddress, new EncryptedPassword("pw")))
                    .ThatDoesNotMatch(new UserEmailLogin("other user", "other@email.com", new EncryptedPassword("pw")))
                    .Build()))
                    .Throws<ItemNotFoundException<UserEmailLogin>>();
            };

        Because of =
            () =>
                _exception =
                    Catch.Exception(() => _validator.Validate(null, new CreatePasswordResetToken(EmailAddress)));

        It should_return_a_validation_failure_for_non_existant_email_address =
            () =>
                _exception.As<CommandValidationException>().ValidationFailures
                    .ShouldContain(x => x.Property == "Email" &&
                                        x.FailureType == ValidationFailureType.DoesNotExist);
    }
}