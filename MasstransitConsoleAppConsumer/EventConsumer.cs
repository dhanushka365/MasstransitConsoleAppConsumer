using EventContract;
using MassTransit;

namespace MasstransitConsoleAppConsumer
{
    public class EventConsumer : IConsumer<ValueEntered>
    {
        public async  Task Consume(ConsumeContext<ValueEntered> context)
        {
            Console.WriteLine("ValueEntered: {0}", context.Message.Value);
        }
       
    }
}
