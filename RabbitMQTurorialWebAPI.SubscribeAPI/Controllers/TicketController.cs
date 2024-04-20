using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQTurorialWebAPI.Common;

namespace RabbitMQTurorialWebAPI.SubscribeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase, IConsumer<TicketCreatedEvent>
{


    public Task Consume(ConsumeContext<TicketCreatedEvent> context)
    {
        throw new NotImplementedException();
    }
}
