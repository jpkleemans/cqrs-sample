using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Core
{
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <typeparam name="T">Type of the event.</typeparam>
        /// <param name="e">The event to publish.</param>
        void PublishEvent<T>(T e) where T : IDomainEvent;
    }
}
