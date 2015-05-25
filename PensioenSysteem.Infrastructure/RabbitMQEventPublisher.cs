using Newtonsoft.Json;
using PensioenSysteem.Domain.Core;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Infrastructure
{
    /// <summary>
    /// RabbitMQ implementation of the EventPublisher.
    /// </summary>
    public class RabbitMQEventPublisher : IEventPublisher
    {
        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <typeparam name="T">Type of the event.</typeparam>
        /// <param name="e">The event to publish.</param>
        public void PublishEvent<T>(T e) where T : IDomainEvent
        {
            // TODO: host, username, pw en exchange configureerbaar maken (factory??)

            var factory = new ConnectionFactory() { HostName = "127.0.0.1", UserName = "cqrs_user", Password = "SeeQueErEs" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    settings.NullValueHandling = NullValueHandling.Include;
                    string message = JsonConvert.SerializeObject(e, settings);
                    var body = Encoding.UTF8.GetBytes(message);
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Headers = new Dictionary<string, object>();
                    properties.Headers.Add("EventType", e.GetType().Name);
                    channel.BasicPublish("PensioenSysteem", e.RoutingKey, properties, body);
                }
            }
        }
    }
}
