using System;
using System.Threading.Tasks;
using MatchingEngine.Client.Models.Trading;

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
        /// <param name="request">The limit order creation information.</param>
        /// <returns>The limit order creation result.</returns>
        Task<LimitOrderResponseModel> CreateLimitOrderAsync(LimitOrderRequestModel request);

        /// <summary>
        /// Cancels the limit order.
        /// </summary>
        /// <param name="limitOrderId">The limit order identifier.</param>
        Task CancelLimitOrderAsync(Guid limitOrderId);
    }
}