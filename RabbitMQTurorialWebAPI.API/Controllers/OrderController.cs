using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQTurorialWebAPI.Common;

namespace RabbitMQTurorialWebAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMessagePublisher _messagePublisher;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IBus _bus;

    public OrderController(IMessagePublisher messagePublisher, IBus bus, IPublishEndpoint publishEndpoint)
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
    public async Task<IActionResult> MassTransitTicketOrder(Ticket ticket)
    {
        await _publishEndpoint.Publish<ITicketOrdered>(new
        {
            UserName = Guid.NewGuid().ToString(),
            ticket.BookedOn,
            ticket.Boarding,
            ticket.Destination
        });

        return Ok();
    }
}
