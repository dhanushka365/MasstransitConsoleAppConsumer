using EventContract;
using MassTransit;
using MasstransitConsoleAppConsumer;

public class Program
{
    public static async Task Main()
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
        
            cfg.ReceiveEndpoint("EventContract:"+nameof(ValueEntered), e =>
            {
                e.Consumer<EventConsumer>();
            });
        });
    
        var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

        await busControl.StartAsync(source.Token);

        try
        {
            Console.WriteLine("Press any key to exit");
            await Task.Run(Console.ReadKey);
        }
        finally
        {
            await busControl.StopAsync();
        }
    }
}
