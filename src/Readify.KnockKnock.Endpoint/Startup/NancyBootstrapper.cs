using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Configuration;

namespace Readify.KnockKnock.Endpoint.Startup
{
    internal class NancyBootstrapper : AutofacNancyBootstrapper
    {
        private readonly IContainer _container;

        public override void Configure(INancyEnvironment environment)
        {
            base.Configure(environment);
            environment.Tracing(true, true);
        }

        public NancyBootstrapper(IContainer container)
        {
            _container = container;
        }

        protected override ILifetimeScope GetApplicationContainer()
        {
            return _container;
        }
    }
}