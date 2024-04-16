using Microsoft.AspNetCore.Mvc;

namespace RabbitMQTurorialWebAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMessagePublisher _messagePublisher;

    public OrderController(IMessagePublisher messagePublisher)
    {
        _messagePublisher = messagePublisher;
    }

    [HttpPost]
    public IActionResult SendOrder(OrderCommand command)
    {
        _messagePublisher.SendMessage(command);
        return Ok(command);
    }
}
