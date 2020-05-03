using System;
using CloudMqttClientOne.MqttLib;

namespace CloudMqttClientOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting CloudMqtt sample program.");
            Console.WriteLine("Press any key to stop\n");
            var prog = new Program(Guid.NewGuid().ToString());
            prog.Start();

            Console.ReadKey();
            prog.Stop();
        }

        IMqtt _client;
        Program(string clientId)
        {
            var connectionString = "tcp://fantastic-teacher.cloudmqtt.com:1883";
            _client = MqttClientFactory.CreateClient(connectionString, clientId, "gnztvlsa", "CZbmTTBjvd8f");
            // Setup some useful client delegate callbacks
            _client.Connected += client_Connected;
            _client.ConnectionLost += _client_ConnectionLost;
           _client.PublishArrived += client_PublishArrived;
        }

        void Start()
        {
            // Connect to broker in 'CleanStart' mode
            Console.WriteLine("Client connecting\n");
            _client.Connect(true); // was true
        }

        void Stop()
        {
            if (_client.IsConnected)
            {
                Console.WriteLine("Client disconnecting\n");
                _client.Disconnect();
                Console.WriteLine("Client disconnected\n");
            }
        }

        void client_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("Client connected to CloudMqtt\n");
            RegisterOurSubscriptions();
            //PublishSomething();
        }

        void _client_ConnectionLost(object sender, EventArgs e)
        {
            Console.WriteLine("Client connection lost\n");
        }

        void RegisterOurSubscriptions()
        {
            Console.WriteLine("Subscribing to globalchoices/357660090106246\n"); // Edmunds Q2
           //onsole.WriteLine("Subscribing to globalchoices/#\n"); // Edmunds Q2
            _client.Subscribe("globalchoices/357660090106246", QoS.AtLeastOnce);
            //_client.Subscribe("globalchoices/#", QoS.AtLeastOnce);
        }

        void PublishSomething()
        {
            Console.WriteLine("Publishing on globalchoices/357660090106246\n");
            _client.Publish("globalchoices/357660090106246", "Door Open", QoS.AtLeastOnce, false);
        }

       
        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            Console.WriteLine("Received Message");
            Console.WriteLine("Topic: " + e.Topic);
            Console.WriteLine("Payload: " + e.Payload);
            Console.WriteLine("Date Time: " + DateTime.Now);
            Console.WriteLine();
            return true;
        }
    }
}
