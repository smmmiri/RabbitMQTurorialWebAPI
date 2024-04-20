using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQTurorialWebAPI.Common;

namespace RabbitMQTurorialWebAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly IMessagePublisher _messagePublisher;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IBus _bus;

    public TicketController(IMessagePublisher messagePublisher, IBus bus, IPublishEndpoint publishEndpoint)
    {
        _messagePublisher = messagePublisher;
        _bus = bus;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public IActionResult SendOrder(OrderCommand command)
    {
        _messagePublisher.SendMessage(command);
        return Ok(command);
    }

    [HttpPost("MassTransit")]
    public async Task<IActionResult> MassTransitTicketOrder(TicketCreatedEvent ticket)
    {
        await _publishEndpoint.Publish<TicketOrderedEvent>(new
        {
            UserName = Guid.NewGuid().ToString()
        });

        return Ok();
    }
}
