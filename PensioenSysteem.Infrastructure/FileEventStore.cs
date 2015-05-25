using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Infrastructure
{
    /// <summary>
    /// EventStore implementation using filesystem for event persistence.
    /// </summary>
    public class FileEventStore : IEventStore
    {
        private Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();
        private readonly string _eventStoreFolder;
        private readonly IEventPublisher _eventPublisher;

        /// <summary>
        /// Descriptor of a single event in the system.
        /// </summary>
        [Serializable]
        private class EventDescriptor
        {
            /// <summary>
            /// Event data.
            /// </summary>
            public DomainEvent EventData;

            /// <summary>
            /// Unique Id of the aggregate.
            /// </summary>
            public Guid Id;

            /// <summary>
            /// The current version of the aggregate.
            /// </summary>
            public int Version;

            /// <summary>
            /// Standard constructor.
            /// </summary>
            public EventDescriptor() // for deserialization
            {

            }

            /// <summary>
            /// Constructor taking parameters for initialisation.
            /// </summary>
            /// <param name="id">The unique Id of the aggregate.</param>
            /// <param name="eventData">The event data.</param>
            /// <param name="version">The current version of the aggregate for concurrency control.</param>
            public EventDescriptor(Guid id, DomainEvent eventData, int version)
            {
                EventData = eventData;
                Version = version;
                Id = id;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventBus">IPublisher implementation to use for publishing events.</param>
        public FileEventStore(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
            _eventStoreFolder = ConfigurationManager.AppSettings["EventStoreFolder"];
        }

        /// <summary>
        /// Save events to storage.
        /// </summary>
        /// <param name="aggregateId">Unique Id of the aggregate to store the events for.</param>
        /// <param name="events">The events to store.</param>
        /// <param name="expectedVersion">The expected current version of the aggregate for concurrency control.</param>
        public void SaveEvents(Guid aggregateId, IEnumerable<DomainEvent> events, int expectedVersion)
        {
            List<EventDescriptor> eventDescriptors;
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }
            else if (eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion && expectedVersion != -1)
            {
                throw new ConcurrencyException();
            }
            var i = expectedVersion;
            foreach (var e in events)
            {
                i++;
                e.Version = i;
                eventDescriptors.Add(new EventDescriptor(aggregateId, e, i));
                _eventPublisher.PublishEvent(e);
            }

            Persist(aggregateId);
        }

        /// <summary>
        /// Get the events for an aggregate.
        /// </summary>
        /// <param name="aggregateId">The unique Id of the aggregate.</param>
        /// <returns>List of events.</returns>
        public List<DomainEvent> GetEventsForAggregate(Guid aggregateId)
        {
            Load(aggregateId);

            List<EventDescriptor> eventDescriptors;
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }
            return eventDescriptors.Select(desc => desc.EventData).ToList();
        }

        /// <summary>
        /// Persist eventlist to disk.
        /// </summary>
        /// <param name="aggregateId">The Id of the aggregate.</param>
        private void Persist(Guid aggregateId)
        {
            // TODO: implement real persistence

            if (!Directory.Exists(_eventStoreFolder))
            {
                Directory.CreateDirectory(_eventStoreFolder);
            }

            string fileName = Path.Combine(_eventStoreFolder, aggregateId.ToString("D"));
            BinaryFormatter ser = new BinaryFormatter();
            using (FileStream stream = File.Create(fileName))
            {
                ser.Serialize(stream, _current);
            }
        }

        /// <summary>
        /// Load eventlist from disk.
        /// </summary>
        /// <param name="aggregateId">The Id of the aggregate.</param>
        private void Load(Guid aggregateId)
        {
            // TODO: implement real persistence

            string fileName = Path.Combine(_eventStoreFolder, aggregateId.ToString("D"));
            if (File.Exists(fileName))
            {
                BinaryFormatter ser = new BinaryFormatter();
                using (FileStream stream = File.OpenRead(fileName))
                {
                    _current = (Dictionary<Guid, List<EventDescriptor>>)ser.Deserialize(stream);
                }
            }
        }
    }

    /// <summary>
    /// Exception to indicate that an aggregate could not be found in the eventstore.
    /// </summary>
    public class AggregateNotFoundException : Exception
    {
    }

    /// <summary>
    /// Exception to indicate a concurrency-issue when changing state.
    /// </summary>
    public class ConcurrencyException : Exception
    {
    }
}
