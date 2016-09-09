using AcklenAvenue.Commands;
using Nancy;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Services;

using designPatterns.Web.Api.Infrastructure.Authentication;
using designPatterns.Web.Api.Infrastructure.Exceptions;
using designPatterns.Web.Api.Modules;

namespace designPatterns.Web.Api.Infrastructure
{
    public static class IdentityExtentions
    {
        public static IUserSession UserSession(this NancyModule module)
        {
            var user = module.Context.CurrentUser as LoggedInUserIdentity;
            if (user == null) throw new NoCurrentUserException();
            return user.UserSession;
        }

        public static UserLoginSession UserLoginSession(this NancyModule module)
        {
            var user = module.Context.CurrentUser as LoggedInUserIdentity;
            if (user == null || user.UserSession.GetType() != typeof(UserLoginSession)) throw new NoCurrentUserException();
            return (UserLoginSession) user.UserSession;
        }
    }
}