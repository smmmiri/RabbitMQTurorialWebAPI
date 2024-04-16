using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace RabbitMQTurorialWebAPI.API;

public class MessagePublisher : IMessagePublisher
{
    public void SendMessage<T>(T message)
    {
        ConnectionFactory connectionFactory = new()
        {
            HostName = "localhost"
        };
        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("Orders", true, false, false, null);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: "Orders", body: body);
    }
}
