using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQTurorialWebAPI.Common;

namespace RabbitMQTurorialWebAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMessagePublisher _messagePublisher;
    private readonly IBus _bus;

    public OrderController(IMessagePublisher messagePublisher, IBus bus)
    {
        _messagePublisher = messagePublisher;
        _bus = bus;
    }

    [HttpPost]
    public IActionResult SendOrder(OrderCommand command)
    {
        _messagePublisher.SendMessage(command);
        return Ok(command);
    }

    [HttpPost("MassTransit")]
    public async Task<IActionResult> MassTransitSendOrder(Ticket ticket)
    {
        if (ticket is not null)
        {
            ticket.BookedOn = DateTime.Now;
            Uri uri = new("rabbitmq://localhost/ticketQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(ticket);
            return Ok();
        }
        return BadRequest();
    }
}
