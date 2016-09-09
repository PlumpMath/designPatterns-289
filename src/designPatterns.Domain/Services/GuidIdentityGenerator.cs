using System;

namespace designPatterns.Domain.Services
{
    public class GuidIdentityGenerator : IIdentityGenerator<Guid>
    {
        public Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}