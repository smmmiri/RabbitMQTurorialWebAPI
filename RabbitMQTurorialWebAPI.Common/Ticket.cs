namespace RabbitMQTurorialWebAPI.Common;

public class Ticket
{
    public string UserName { get; set; } = Guid.NewGuid().ToString();
    public DateTime BookedOn { get; set; }
    public string? Boarding { get; set; }
    public string? Destination { get; set; }
}
