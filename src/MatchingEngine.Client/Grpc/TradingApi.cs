using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Contracts.Api;
using MatchingEngine.Client.Contracts.Incoming;

namespace MatchingEngine.Client.Grpc
{
    internal class TradingApi : ITradingApi
    {
        private readonly TradingService.TradingServiceClient _client;

        public TradingApi(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new TradingService.TradingServiceClient(channel);
        }

        public async Task<Response> CreateLimitOrderAsync(LimitOrder request, CancellationToken cancellationToken = default)
        {
            return await _client.LimitOrderAsync(request, cancellationToken: cancellationToken);
        }

        public async Task<Response> CancelLimitOrderAsync(LimitOrderCancel request, CancellationToken cancellationToken = default)
        {
            return await _client.CancelLimitOrderAsync(request, cancellationToken: cancellationToken);
        }

        public async Task<MarketOrderResponse> CreateMarketOrderAsync(MarketOrder request, CancellationToken cancellationToken = default)
        {
            return await _client.MarketOrderAsync(request, cancellationToken: cancellationToken);
        }
    }
}