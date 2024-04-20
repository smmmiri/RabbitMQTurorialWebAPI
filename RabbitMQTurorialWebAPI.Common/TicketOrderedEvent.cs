namespace RabbitMQTurorialWebAPI.Common;

public record TicketOrderedEvent(Guid Id, DateTime OrderedOn);
