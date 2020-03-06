using System.Collections.Generic;
using System.Threading.Tasks;
using MatchingEngine.Client.Models.Balances;

namespace MatchingEngine.Client.Api
{
    /// <summary>
    /// Provides methods for work with matching engine balance API. 
    /// </summary>
    public interface IBalancesApi
    {
        /// <summary>
        /// Returns all assets balances.
        /// </summary>
        /// <param name="walletId">The wallet identifier.</param>
        /// <returns>A collection of assets balances.</returns>
        Task<IReadOnlyList<BalanceModel>> GetAllAsync(string walletId);

        /// <summary>
        /// Returns a balance by asset identifier.
        /// </summary>
        /// <param name="walletId">The wallet identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns>Asset balance.</returns>
        Task<BalanceModel> GetByAssetIdAsync(string walletId, string assetId);
    }
}