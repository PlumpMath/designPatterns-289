using System;
using AutoMapper;
using Autofac;
using designPatterns.Domain.Entities;
using designPatterns.Web.Api.Requests;
using designPatterns.Web.Api.Responses.Admin;

namespace designPatterns.Web.Api.Infrastructure.Configuration
{
    public class ConfigureAutomapperMappings : IBootstrapperTask<ContainerBuilder>
    {
        #region IBootstrapperTask<ContainerBuilder> Members

        public Action<ContainerBuilder> Task
        {
            get
            {
                return container =>
                    {
                        Mapper.CreateMap<User, AdminUserResponse>();
                        Mapper.CreateMap<UserAbility, UserAbilityRequest>().ReverseMap();
                    };
            }
        }

        #endregion
    }
}