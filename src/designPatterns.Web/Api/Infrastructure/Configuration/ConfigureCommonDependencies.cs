using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using AutoMapper;
using BlingBag;
using Castle.DynamicProxy;
using log4net;
using Newtonsoft.Json;
using designPatterns.Data;
using designPatterns.Domain;
using designPatterns.Domain.Services;
using AcklenAvenue.Commands;
using designPatterns.Web.Api.Infrastructure.Authentication;
using designPatterns.Web.Api.Infrastructure.Authentication.Roles;

namespace designPatterns.Web.Api.Infrastructure.Configuration
{
    
    public class ConfigureCommonDependencies : IBootstrapperTask<ContainerBuilder>
    {
        #region IBootstrapperTask<ContainerBuilder> Members

        public Action<ContainerBuilder> Task
        {
            get
            {
                return container =>
                       {
                           AutoRegisterDataAndDomain(container);
                           container.RegisterInstance(Mapper.Engine).As<IMappingEngine>();
                           container.RegisterType<BaseUrlProvider>().As<IBaseUrlProvider>();
                           container.RegisterType<ApiUserMapper>().As<IApiUserMapper<Guid>>();
                           container.RegisterInstance(LogManager.GetLogger("Logger")).As<ILog>();
                           log4net.Config.XmlConfigurator.Configure();
                          
                           ConfigureCommandAndEventHandlers(container);

                           AutoRegisterAllDomainEvents(container);
                           AutoRegisterAllCommandHandlers(container);
                           RegisterUsersFeutures(container);
                       };
            }
        }

        void RegisterUsersFeutures(ContainerBuilder container)
        {


            var bytes = Properties.Resources.RolesFeatures;
            var reader = new StreamReader(new MemoryStream(bytes), Encoding.Default);


            var usersRoles = new JsonSerializer().Deserialize<IEnumerable<UsersRoles>>(new JsonTextReader(reader));
            

            container.RegisterType<MenuProvider>().As<IMenuProvider>().WithParameter("usersRoles",usersRoles);

        }

        void AutoRegisterAllCommandHandlers(ContainerBuilder container)
        {
            container.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.GetInterfaces().Any(i => i.Name.StartsWith("ICommandHandler")))
                .AsImplementedInterfaces();
        }

        void AutoRegisterAllDomainEvents(ContainerBuilder container)
        {
            container.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.GetInterfaces().Any(i => i.Name.StartsWith("IBlingHandler")))
                .AsImplementedInterfaces();
        }

        #endregion

        static void ConfigureCommandAndEventHandlers(ContainerBuilder container)
        {
            container.RegisterType<BlingInitializer<DomainEvent>>().As<IBlingInitializer<DomainEvent>>();
            container.RegisterType<BlingConfigurator>().As<IBlingConfigurator<DomainEvent>>();

         
            
            container.RegisterType<AutoFacBlingDispatcher>().As<IBlingDispatcher>();
          
            container.RegisterType<ImmediateCommandDispatcher>().Named<ICommandDispatcher>("CommandDispatcher");

            container.RegisterDecorator<ICommandDispatcher>((c, inner) => new CommandDispatcherLogger(inner,c.Resolve<ILog>()), "CommandDispatcher");
        }

      


        static void AutoRegisterDataAndDomain(ContainerBuilder container)
        {
            container
                .RegisterAssemblyTypes(new[]
                                       {
                                           typeof (ReadOnlyRepository).Assembly,
                                           typeof (IEntity).Assembly,
                                       })
                .Where(x => x.GetInterfaces().Any())
                .Where(x => typeof(ICommandHandler).IsAssignableFrom(x)!=true)
                
                .AsImplementedInterfaces();
        }
    }
}