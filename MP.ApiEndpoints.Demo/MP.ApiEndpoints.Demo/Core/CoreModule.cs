using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MP.ApiEndpoints.Demo.Core.Application.Contracts;
using MP.ApiEndpoints.Demo.Core.Application.Services;

namespace MP.ApiEndpoints.Demo.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            //builder.RegisterAutoMapper(currentAssembly);

            builder.RegisterMediatR(currentAssembly);

            //! User Service
            builder
                .RegisterType<UserService>()
                .As(typeof(IUserService))
                .InstancePerLifetimeScope();
        }
    }
}