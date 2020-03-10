using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Contracts.Api;
using MatchingEngine.Client.Models.Balances;
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

        public async Task<IReadOnlyList<BalanceModel>> GetAllAsync(string walletId)
        {
            var response = await _client.GetAllAsync(new BalancesGetAllRequest {WalletId = walletId});

            var timestamp = response.Timestamp.ToDateTime();

            return response.Balances
                .Select(o => new BalanceModel(o, timestamp))
                .ToList();
        }

        public async Task<BalanceModel> GetByAssetIdAsync(string walletId, string assetId)
        {
            var response = await _client.GetByAssetIdAsync(new BalancesGetByAssetIdRequest
                {WalletId = walletId, AssetId = assetId});

            if (response.Balance == null)
                return null;

            var timestamp = response.Timestamp.ToDateTime();
            
            return new BalanceModel(response.Balance, timestamp);
        }
    }
}