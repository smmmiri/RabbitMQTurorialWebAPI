namespace RabbitMQTurorialWebAPI.API;

public interface IMessagePublisher
{
    void SendMessage<T>(T message);
}
