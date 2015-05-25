using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Core
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _changes = new List<DomainEvent>();

        /// <summary>
        /// Unique Id of the aggregate root.
        /// </summary>
        public abstract Guid Id { get; }

        /// <summary>
        /// Aggregate version for concurrency control.
        /// </summary>
        public int Version { get; internal set; }

        /// <summary>
        /// List of uncommitted changes.
        /// </summary>
        public IEnumerable<DomainEvent> GetUncommittedChanges()
        {
            return _changes;
        }

        /// <summary>
        /// Mark all uncommitted changes as committed.
        /// </summary>
        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        /// <summary>
        /// Rebuild the state from event-history.
        /// </summary>
        /// <param name="history">The events to use for rebuilding the state.</param>
        public void LoadFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var e in history)
            {
                ApplyChange(e, false);
            }
        }

        /// <summary>
        /// Aply a change based on an event.
        /// </summary>
        /// <param name="e">The event to apply.</param>
        protected void ApplyChange(DomainEvent e)
        {
            ApplyChange(e, true);
        }

        /// <summary>
        /// Aply a change based on an event.
        /// </summary>
        /// <param name="e">The event to apply.</param>
        /// <param name="isNew">Indication whether this is a new event (true) that needs to be added to the 
        /// list of uncommitted changes or not (false).</param>
        private void ApplyChange(DomainEvent e, bool isNew)
        {
            // handle the event
            HandleEvent(e);

            // add event to list of uncommitted events
            if (isNew)
            {
                _changes.Add(e as DomainEvent);
            }
        }

        /// <summary>
        /// Call the appropriate handle method on the derived Aggregate class based on the event type. 
        /// </summary>
        /// <param name="e">The event to handle.</param>
        private void HandleEvent(DomainEvent e)
        {
            var handleMethod = this.GetType().GetMethod("Handle", new Type[] { e.GetType() });
            handleMethod.Invoke(this, new object[] { e });
        }
    }
}
