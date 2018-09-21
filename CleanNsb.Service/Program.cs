using NServiceBus;

namespace CleanNsb.Service
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var config = new EndpointConfiguration("CleanNsb");
            var pipeline = config.Pipeline;
            pipeline.Register(
                behavior: new RepositorySavingBehaviour(),
                description: "Save changes to the domain model after event handling");
        }
    }
}