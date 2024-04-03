using RabbitMQ.Client;
using System.Text;

namespace ProducerApp
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using(var conn = factory.CreateConnection())
            using(var channel = conn.CreateModel())
            {
                channel.QueueDeclare("BasicTest",false,false,false,null);

                string message = "Starting with .NET core rabbitmq";
                var body=Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("","BasicTest",null,body);
                Console.WriteLine("Sent Message {0}....",message);
            }

            Console.WriteLine("Press [enter] to exit the Sender App...");
            Console.ReadLine();
        }
    }
}
