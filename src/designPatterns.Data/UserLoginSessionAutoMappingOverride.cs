using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using designPatterns.Domain.Entities;

namespace designPatterns.Data
{
    public class UserLoginSessionAutoMappingOverride : IAutoMappingOverride<UserLoginSession>
    {
        public void Override(AutoMapping<UserLoginSession> mapping)
        {            
        }
    }
}