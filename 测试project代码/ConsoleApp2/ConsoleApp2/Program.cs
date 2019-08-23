using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616/");
            using (IConnection connection =factory.CreateConnection())
            {
                using (ISession session = connection.CreateSession())
                {
                    IMessageProducer producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("demo"));
                    int i = 0;
                    while (!Console.KeyAvailable)
                    {
                        ITextMessage msg = producer.CreateTextMessage();
                        msg.Text = i.ToString();
                        Console.WriteLine($"向Topic发送消息:{i.ToString()}");
                        producer.Send(msg);
                        Thread.Sleep(2000);
                        i++;
                    }
                }
            }
        } 
    }
}
