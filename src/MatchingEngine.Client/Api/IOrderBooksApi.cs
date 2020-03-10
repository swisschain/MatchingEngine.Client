using System.Collections.Generic;
using System.Threading.Tasks;
using MatchingEngine.Client.Models.OrderBooks;

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
        /// <returns>A collection of order books.</returns>
        Task<IReadOnlyList<OrderBookSnapshotModel>> GetAllAsync();
    }
}