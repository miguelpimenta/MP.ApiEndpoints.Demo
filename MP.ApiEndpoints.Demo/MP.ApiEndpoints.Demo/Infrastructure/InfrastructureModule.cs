using Autofac;
using Microsoft.Extensions.Configuration;
using MP.ApiEndpoints.Demo.Core.Application.Contracts;
using MP.ApiEndpoints.Demo.Infrastructure.Contexts;
using MP.ApiEndpoints.Demo.Infrastructure.Repositories;

namespace MP.ApiEndpoints.Demo.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration _config;

        public InfrastructureModule(IConfiguration config)
        {
            _config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder
                .RegisterType<AppDbContext>()
                .WithParameter("options", DbContextOptionsFactory.Get(_config))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}