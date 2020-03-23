using System;
using System.Globalization;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
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

        public async Task CashInAsync(string walletId, string assetId, decimal amount)
        {
            await _client.CashInOutAsync(new CashInOutOperation
            {
                Id = Guid.NewGuid().ToString(),
                WalletId = walletId,
                AssetId = assetId,
                Volume = amount.ToString(CultureInfo.InvariantCulture),
                MessageId = Guid.NewGuid().ToString(),
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
            });
        }

        public async Task CashOutAsync(string walletId, string assetId, decimal amount)
        {
            await _client.CashInOutAsync(new CashInOutOperation
            {
                Id = Guid.NewGuid().ToString(),
                WalletId = walletId,
                AssetId = assetId,
                Volume = (-amount).ToString(CultureInfo.InvariantCulture),
                MessageId = Guid.NewGuid().ToString(),
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
            });
        }
    }
}