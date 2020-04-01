using System.Threading;
using System.Threading.Tasks;
using MatchingEngine.Client.Contracts.Incoming;

namespace MatchingEngine.Client.Api
{
    /// <summary>
    /// Provides methods for work with matching engine trading API. 
    /// </summary>
    public interface ITradingApi
    {
        /// <summary>
        /// Creates new limit order.
        /// </summary>
        /// <returns>The limit order creation result.</returns>
        Task<Response> CreateLimitOrderAsync(LimitOrder request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the limit order.
        /// </summary>
        Task<Response> CancelLimitOrderAsync(LimitOrderCancel request, CancellationToken cancellationToken = default);
    }
}