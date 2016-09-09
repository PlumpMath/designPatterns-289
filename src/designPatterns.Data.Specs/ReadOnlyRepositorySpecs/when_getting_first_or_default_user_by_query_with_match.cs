using System.Collections.Generic;
using System.Linq;
using AcklenAvenue.Data.NHibernate.Testing;
using designPatterns.Domain;
using designPatterns.Domain.Entities;
using designPatterns.Domain.ValueObjects;
using Machine.Specifications;
using NHibernate;

namespace designPatterns.Data.Specs.ReadOnlyRepositorySpecs
{
    public class when_getting_first_or_default_user_by_query_with_match
    {
        static ReadOnlyRepository _readOnlyRepository;
        static UserEmailLogin _result;
        static UserEmailLogin _userToFind;

        Establish context =
            () =>
                {
                    ISession session = InMemorySession.New(new MappingScheme("Test"));

                    var users = new List<UserEmailLogin>
                                    {
                                        new UserEmailLogin("test1", "test1@test.com", new EncryptedPassword("password")),
                                        new UserEmailLogin("test2-match", "test2@test.com", new EncryptedPassword("password")),
                                        new UserEmailLogin("test3", "test2@test.com", new EncryptedPassword("password"))
                                    };

                    _userToFind = users.First(x => x.Name == "test2-match");

                    users.ForEach(x => session.Save(x));
                    session.Flush();

                    _readOnlyRepository = new ReadOnlyRepository(session);
                };

        Because of =
            () => _result = _readOnlyRepository.FirstOrDefault<UserEmailLogin>(x => x.Name == "test2-match");

        It should_return_matching_user =
            () => _result.ShouldBeLike(_userToFind);
    }
}