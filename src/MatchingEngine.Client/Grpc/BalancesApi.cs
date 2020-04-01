using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Contracts.Api;
using MatchingEngine.Client.Contracts.Balances;

namespace MatchingEngine.Client.Grpc
{
    internal class BalancesApi : IBalancesApi
    {
        private readonly BalancesService.BalancesServiceClient _client;

        public BalancesApi(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new BalancesService.BalancesServiceClient(channel);
        }

        public async Task<BalancesGetAllResponse> GetAllAsync(BalancesGetAllRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.GetAllAsync(request, cancellationToken: cancellationToken);
        }

        public async Task<BalancesGetByAssetIdResponse> GetByAssetIdAsync(BalancesGetByAssetIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.GetByAssetIdAsync(request, cancellationToken: cancellationToken);
        }
    }
}