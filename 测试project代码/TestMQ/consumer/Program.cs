using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("订阅者");
                IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
                using (IConnection connection=factory.CreateConnection())
                {
                    connection.ClientId = "123456789";
                    connection.Start();

                    using (ISession session=connection.CreateSession())
                    {
                        IMessageConsumer consumer = session.CreateDurableConsumer(
                            new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("zzz"), "zjm", null, false);
                        consumer.Listener += new MessageListener(consumer_Listener);
                        Console.ReadLine();
                    }
                    connection.Stop();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常{ex.Message}");
                Console.ReadLine();
            }
        }
        static void consumer_Listener(IMessage message)
        {
            try
            {
                ITextMessage msg = (ITextMessage)message;
                Console.WriteLine($"收到消息：{msg.Text}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常{ex.Message}");
            }
        }
    }
}
