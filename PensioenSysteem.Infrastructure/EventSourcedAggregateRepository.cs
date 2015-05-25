using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Infrastructure
{
    /// <summary>
    /// Generic repository for aggregate state.
    /// </summary>
    /// <typeparam name="T">The type of the aggregate.</typeparam>
    public class EventSourcedAggregateRepository<T> : IAggregateRepository<T> where T : AggregateRoot, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventStore">The eventstore to use for persisting events.</param>
        public EventSourcedAggregateRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        /// <summary>
        /// Save the state of an aggregate.
        /// </summary>
        /// <param name="aggregate">De aggregate.</param>
        /// <param name="expectedVersion">The expected version for concurrency control.</param>
        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            _eventStore.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }

        /// <summary>
        /// Get the state of an aggregate by unique Id.
        /// </summary>
        /// <param name="id">The unique Id of the aggregate to get the state for.</param>
        /// <returns>An initialized aggregate.</returns>
        public T GetById(Guid id)
        {
            var obj = new T();//lots of ways to do this
            var e = _eventStore.GetEventsForAggregate(id);
            obj.LoadFromHistory(e);
            return obj;
        }
    }
}
