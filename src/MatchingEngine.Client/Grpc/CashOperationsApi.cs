using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Contracts.Api;
using MatchingEngine.Client.Contracts.Incoming;

namespace MatchingEngine.Client.Grpc
{
    internal class CashOperationsApi : ICashOperationsApi
    {
        private readonly CashService.CashServiceClient _client;

        public CashOperationsApi(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new CashService.CashServiceClient(channel);
        }

        public async Task<Response> CashInOutAsync(CashInOutOperation request, CancellationToken cancellationToken = default)
        {
            return await _client.CashInOutAsync(request, cancellationToken: cancellationToken);
        }
    }
}