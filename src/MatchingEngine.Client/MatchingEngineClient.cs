using System;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Grpc;

namespace MatchingEngine.Client
{
    /// <inheritdoc /> 
    public class MatchingEngineClient : IMatchingEngineClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MatchingEngineClient"/>.
        /// </summary>
        /// <param name="settings">The matching engine client settings.</param>
        public MatchingEngineClient(MatchingEngineClientSettings settings)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            if (!string.IsNullOrEmpty(settings.BalancesServiceAddress))
                Balances = new BalancesApi(settings.BalancesServiceAddress);

            if (!string.IsNullOrEmpty(settings.OrderBooksServiceAddress))
                OrderBooks = new OrderBooksApi(settings.OrderBooksServiceAddress);
        }

        /// <inheritdoc />
        public IBalancesApi Balances { get; }

        /// <inheritdoc />
        public IOrderBooksApi OrderBooks { get; }
    }
}