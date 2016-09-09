using Autofac.Extras.DynamicProxy2;

namespace designPatterns.Notifications
{
   
    public interface ICommandDispatcher
    {
        void Dispatch(IUserSession userSession, object command);
    }
}