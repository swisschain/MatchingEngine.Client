using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Lykke.Matching.Engine.Incoming;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Models.Balances;

namespace MatchingEngine.Client.Grpc
{
    internal class BalancesApi : IBalancesApi
    {
        private readonly BalancesService.BalancesServiceClient _client;

        public BalancesApi(string address)
        {
            var balancesServiceChannel = GrpcChannel.ForAddress(address);
            _client = new BalancesService.BalancesServiceClient(balancesServiceChannel);
        }

        public async Task<IReadOnlyList<BalanceModel>> GetAllAsync(string walletId)
        {
            var response = await _client.GetAllAsync(new BalancesGetAllRequest {WalletId = walletId});

            var timestamp = response.Timestamp.ToDateTime();

            return response.Balances
                .Select(o => new BalanceModel
                {
                    AssetId = o.AssetId,
                    Amount = decimal.Parse(o.Amount),
                    Reserved = decimal.Parse(o.Reserved),
                    Timestamp = timestamp
                })
                .ToList();
        }

        public async Task<BalanceModel> GetByAssetIdAsync(string walletId, string assetId)
        {
            var response = await _client.GetByAssetIdAsync(new BalancesGetByAssetIdRequest
                {WalletId = walletId, AssetId = assetId});

            if (response.Balance == null)
                return null;

            return new BalanceModel
            {
                AssetId = response.Balance.AssetId,
                Amount = decimal.Parse(response.Balance.Amount),
                Reserved = decimal.Parse(response.Balance.Reserved),
                Timestamp = response.Timestamp.ToDateTime()
            };
        }
    }
}