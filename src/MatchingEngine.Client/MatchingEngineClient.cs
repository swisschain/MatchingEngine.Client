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
            
            Balances = new BalancesApi(settings.BalancesServiceAddress);
        }

        /// <inheritdoc />
        public IBalancesApi Balances { get; }
    }
}