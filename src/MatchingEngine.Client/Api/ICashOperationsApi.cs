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
    }
}