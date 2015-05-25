using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Core
{
    public interface IDomainEvent
    {
        string RoutingKey { get; set; }
        Guid CorrelationId { get; set; }
        Guid Id { get; set; }
        int Version { get; set; }
    }
}
