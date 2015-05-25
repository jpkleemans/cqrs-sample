using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Core
{
    /// <summary>
    /// Repository interface.
    /// </summary>
    /// <typeparam name="T">Aggregate type the repository is for.</typeparam>
    public interface IAggregateRepository<T> where T : AggregateRoot, new()
    {
        /// <summary>
        /// Save the state of an aggregate.
        /// </summary>
        /// <param name="aggregate">De aggregate.</param>
        /// <param name="expectedVersion">The expected version for concurrency control.</param>
        void Save(AggregateRoot aggregate, int expectedVersion);

        /// <summary>
        /// Get the state of an aggregate by unique Id.
        /// </summary>
        /// <param name="id">The unique Id of the aggregate to get the state for.</param>
        /// <returns>An initialized aggregate.</returns>
        T GetById(Guid id);
    }
}
