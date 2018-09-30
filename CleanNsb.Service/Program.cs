using CleanNsb.Meters;
using CleanNsb.Meters.Events;
using Microsoft.EntityFrameworkCore;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace CleanNsb.Service
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "ClientUI";

            MigrateDatabase();

            var endpointConfiguration = new EndpointConfiguration("CleanNsb")
                .ConfigureLogging()
                .ConfigureTransport()
                .ConfigureConventions()
                .ConfigureRoutes()
                .ConfigureDependencies()
                .SaveRepositoryAfterHandlingMessages();

            var endpointInstance = await Endpoint.Start(endpointConfiguration);

            await SimulateEventAsync(endpointInstance);

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            await endpointInstance.Stop();
        }

        private static void MigrateDatabase()
        {
            var db = new Repository(DbOptions);
            db.Database.EnsureCreated();
        }

        private static async Task SimulateEventAsync(IEndpointInstance endpointInstance)
        {
            await endpointInstance.Publish(new MeterReadingTaken
            {
                Mpxn = 1234,
                Reading = 12,
            });
        }

        private static EndpointConfiguration ConfigureLogging(this EndpointConfiguration config) => config;

        private static EndpointConfiguration ConfigureTransport(this EndpointConfiguration config)
        {
            config.UseTransport<LearningTransport>();
            return config;
        }

        private static EndpointConfiguration ConfigureConventions(this EndpointConfiguration config)
        {
            var conventions = config.Conventions();
            //conventions.DefiningCommandsAs(type => type.Namespace == "MyNamespace.Messages.Commands");
            conventions.DefiningEventsAs(type => type.Namespace == "CleanNsb.Meters.Events");
            return config;
        }

        private static EndpointConfiguration ConfigureRoutes(this EndpointConfiguration config) => config;

        private static EndpointConfiguration ConfigureDependencies(this EndpointConfiguration config)
        {
            config.RegisterComponents(components =>
            {
                components.ConfigureComponent(() => DbOptions, DependencyLifecycle.SingleInstance);
                components.ConfigureComponent<Repository>(DependencyLifecycle.InstancePerUnitOfWork);
                components.ConfigureComponent<MetersAggregateRoot>(builder => builder.Build<Repository>(), DependencyLifecycle.InstancePerUnitOfWork);
                components.ConfigureComponent<MeterReadingTakenFeature>(DependencyLifecycle.InstancePerUnitOfWork);
                //components.ConfigureComponent<MessageContext>(builder => builder.Build<NServiceBusMessageContext>(), DependencyLifecycle.InstancePerUnitOfWork);
            });
            return config;
        }

        private static DbContextOptions DbOptions =>
            new DbContextOptionsBuilder()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CleanNsb;Trusted_Connection=True;")
                .Options;

        private static EndpointConfiguration SaveRepositoryAfterHandlingMessages(this EndpointConfiguration config)
        {
            var pipeline = config.Pipeline;
            pipeline.Register(
                behavior: new RepositorySavingBehaviour(),
                description: "Save changes to the domain model after event handling");
            return config;
        }
    }

    internal class NServiceBusMessageContext : MessageContext
    {
        private readonly IPipelineContext context;

        public NServiceBusMessageContext(IPipelineContext context)
        {
            this.context = context;
        }

        public void Instruct<T>(T command)
        {
        }

        public void Publish<T>(T @event)
        {
            context.Publish(@event).GetAwaiter().GetResult();
        }
    }
}