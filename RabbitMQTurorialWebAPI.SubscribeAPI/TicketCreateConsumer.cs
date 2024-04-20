using MassTransit;
using RabbitMQTurorialWebAPI.Common;

namespace RabbitMQTurorialWebAPI.SubscribeAPI;

public class TicketCreateConsumer : IConsumer<TicketCreatedEvent>
{
    public Task Consume(ConsumeContext<TicketCreatedEvent> context)
    {
        Console.WriteLine($"New Created Ticket => Id: {context.Message.Id}, Datetime: {context.Message.CreatedOn}");
        return Task.CompletedTask;
    }
}
