using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQTurorialWebAPI.Common;

namespace RabbitMQTurorialWebAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController(IPublishEndpoint publishEndpoint) : ControllerBase
{
    [HttpPost("MassTransit")]
    public async Task<IActionResult> MassTransitTicketOrder()
    {
        await publishEndpoint.Publish(new TicketCreatedEvent(Guid.NewGuid(), DateTime.Now));
        return Ok();
    }
}
