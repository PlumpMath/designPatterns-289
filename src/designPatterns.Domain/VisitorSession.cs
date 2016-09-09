using System;
using AcklenAvenue.Commands;
using designPatterns.Domain.Services;


namespace designPatterns.Domain
{
    public class VisitorSession : IUserSession
    {
        #region IUserSession Members

        public Guid Id { get; private set; }

        #endregion
    }
}