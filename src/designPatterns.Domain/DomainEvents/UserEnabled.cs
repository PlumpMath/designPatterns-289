using System;

namespace designPatterns.Domain.DomainEvents
{
    public class UserEnabled
    {
        public Guid id { get; protected set; }

        public UserEnabled(Guid id)
        {
            this.id = id;
        }

        protected UserEnabled()
        {
            
        }
    }
}