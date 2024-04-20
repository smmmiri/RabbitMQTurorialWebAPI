namespace RabbitMQTurorialWebAPI.Common;

public class Ticket
{
    public DateTime BookedOn { get; set; }
    public string? Boarding { get; set; }
    public string? Destination { get; set; }
}
