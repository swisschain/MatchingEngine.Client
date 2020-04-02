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
        Task<Response> CreateLimitOrderAsync(LimitOrder request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the limit order.
        /// </summary>
        Task<Response> CancelLimitOrderAsync(LimitOrderCancel request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates new market order.
        /// </summary>
        Task<MarketOrderResponse> CreateMarketOrderAsync(MarketOrder request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates multiple limit orders.
        /// </summary>
        Task<MultiLimitOrderResponse> MultiLimitOrderAsync(MultiLimitOrder request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels multiple limit orders.
        /// </summary>
        Task<Response> MassCancelLimitOrderAsync(LimitOrderMassCancel request, CancellationToken cancellationToken = default);
    }
}