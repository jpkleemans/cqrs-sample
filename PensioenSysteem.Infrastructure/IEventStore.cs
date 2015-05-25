using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Infrastructure
{
    /// <summary>
    /// Eventstore interface.
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Save events to storage.
        /// </summary>
        /// <param name="aggregateId">Unique Id of the aggregate to store the events for.</param>
        /// <param name="events">The events to store.</param>
        /// <param name="expectedVersion">The expected current version of the aggregate for concurrency control.</param>
        void SaveEvents(Guid aggregateId, IEnumerable<DomainEvent> events, int expectedVersion);

        /// <summary>
        /// Get the events for an aggregate.
        /// </summary>
        /// <param name="aggregateId">The unique Id of the aggregate.</param>
        /// <returns>List of events.</returns>
        List<DomainEvent> GetEventsForAggregate(Guid aggregateId);
    }
}
