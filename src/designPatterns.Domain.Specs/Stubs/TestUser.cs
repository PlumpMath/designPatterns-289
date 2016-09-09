using System;
using designPatterns.Domain.Entities;
using designPatterns.Domain.ValueObjects;

namespace designPatterns.Domain.Specs.Stubs
{
    public class TestUser : UserEmailLogin
    {
        public TestUser(Guid userId, string name, string password)
        {
            Id = userId;
            Name = name;
            this.EncryptedPassword = password;
        }
    }
}