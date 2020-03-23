using System.Threading.Tasks;

namespace MatchingEngine.Client.Api
{
    /// <summary>
    /// Provides methods for work with matching engine cash operations API. 
    /// </summary>
    public interface ICashOperationsApi
    {
        /// <summary>
        /// Cash-in an amount.
        /// </summary>
        /// <param name="walletId">The wallet identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="amount">The amount.</param>
        Task CashInAsync(string walletId, string assetId, decimal amount);

        /// <summary>
        /// Cash-out an amount.
        /// </summary>
        /// <param name="walletId">The wallet identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="amount">The amount.</param>
        Task CashOutAsync(string walletId, string assetId, decimal amount);
    }
}