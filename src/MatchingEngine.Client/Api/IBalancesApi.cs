using System.Threading;
using System.Threading.Tasks;
using MatchingEngine.Client.Contracts.Balances;

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
        Task<BalancesGetAllResponse> GetAllAsync(BalancesGetAllRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a balance by asset identifier.
        /// </summary>
        Task<BalancesGetByAssetIdResponse> GetByAssetIdAsync(BalancesGetByAssetIdRequest request, CancellationToken cancellationToken = default);
    }
}