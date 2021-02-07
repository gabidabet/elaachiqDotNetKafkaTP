using System;
using Confluent.Kafka;
using MyWebApplications;
using MyWebApplications.Model;

using Newtonsoft.Json;

namespace MyWebApplications
{
    public class KafkaProducer
    {
        public string BootstrapServers = "192.168.1.110:9092";
        public string topic = "test1";
        private IProducer<Null, string> preducer;

        public KafkaProducer()
        {
            var config = new ProducerConfig { BootstrapServers = this.BootstrapServers, };
            preducer = new ProducerBuilder<Null, string>(config).Build();
        }

        public void preduceMessage(long id, Data data)
        {
            string serialzedObject = JsonConvert.SerializeObject(data);
            preducer.ProduceAsync(topic, new Message<Null, string> { Value = serialzedObject });
            Console.WriteLine("sanding data is done");
        }

    }
}