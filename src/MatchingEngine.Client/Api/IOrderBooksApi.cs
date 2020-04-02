using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MatchingEngine.Client.Contracts.Outgoing;

namespace MatchingEngine.Client.Api
{
    /// <summary>
    /// Provides methods for work with matching engine order books API. 
    /// </summary>
    public interface IOrderBooksApi
    {
        /// <summary>
        /// Returns all order books.
        /// </summary>
        Task<IReadOnlyList<OrderBookSnapshot>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}