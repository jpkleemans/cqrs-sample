using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Core
{
    public class DomainCommand : IDomainCommand
    {
        public Guid CorrelationId { get; set; }
        public int Version { get; set; }
    }
}
