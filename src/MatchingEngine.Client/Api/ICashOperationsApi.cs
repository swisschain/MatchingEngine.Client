using System.Threading;
using System.Threading.Tasks;
using MatchingEngine.Client.Contracts.Incoming;

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
        Task<Response> CashInOutAsync(CashInOutOperation request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Transfers cash.
        /// </summary>
        Task<Response> CashTransferAsync(CashTransferOperation request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Changes reserved amount for an asset.
        /// </summary>
        Task<Response> ReservedCashInOutAsync(ReservedCashInOutOperation request, CancellationToken cancellationToken = default);
    }
}