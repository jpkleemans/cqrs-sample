using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Core
{
    [Serializable] // nodig voor serialisatie door FileEventStore
    public class DomainEvent : IDomainEvent
    {
        public string RoutingKey { get; set; }
        public Guid CorrelationId { get; set; }
        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}
