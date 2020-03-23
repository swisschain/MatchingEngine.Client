using MatchingEngine.Client.Api;

namespace MatchingEngine.Client
{
    /// <summary>
    /// Matching engine service client.
    /// </summary>
    public interface IMatchingEngineClient
    {
        /// <summary>
        /// Balances API.
        /// </summary>
        IBalancesApi Balances { get; }
        
        /// <summary>
        /// Order books API.
        /// </summary>
        IOrderBooksApi OrderBooks { get; }
        
        /// <summary>
        /// Cash operations API.
        /// </summary>
        ICashOperationsApi CashOperations { get; }
    }
}