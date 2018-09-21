using NServiceBus.Pipeline;
using System;
using System.Threading.Tasks;

namespace CleanNsb.Service
{
    public class RepositorySavingBehaviour : Behavior<IIncomingLogicalMessageContext>
    {
        public override async Task Invoke(IIncomingLogicalMessageContext context, Func<Task> next)
        {
            var repository = context.Builder.Build<Repository>();
            await next();
            await repository.SaveChangesAsync();
        }
    }
}