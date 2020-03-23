using System;
using System.Globalization;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Contracts.Api;
using MatchingEngine.Client.Contracts.Incoming;
using MatchingEngine.Client.Models.Trading;

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

        public async Task<LimitOrderResponseModel> CreateLimitOrderAsync(LimitOrderRequestModel request)
        {
            var response = await _client.LimitOrderAsync(new LimitOrder
            {
                Uid = request.Id.ToString(),
                AssetPairId = request.AssetPairId,
                Price = request.Price.ToString(CultureInfo.InvariantCulture),
                Volume = request.Volume.ToString(CultureInfo.InvariantCulture),
                WalletId = request.WalletId,
                CancelAllPreviousLimitOrders = request.CancelAllPreviousLimitOrders,
                Timestamp = request.Timestamp.ToTimestamp(),
                Type = LimitOrder.Types.LimitOrderType.Limit,
                TimeInForce = LimitOrder.Types.OrderTimeInForce.Gtc,
                MessageId = Guid.NewGuid().ToString()
            });

            return new LimitOrderResponseModel(response);
        }

        public async Task CancelLimitOrderAsync(Guid limitOrderId)
        {
            var request = new LimitOrderCancel
            {
                Uid = Guid.NewGuid().ToString(),
                MessageId = Guid.NewGuid().ToString()
            };

            request.LimitOrderId.Add(limitOrderId.ToString());

            await _client.CancelLimitOrderAsync(request);
        }
    }
}