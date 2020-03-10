using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Contracts.Api;
using MatchingEngine.Client.Models.OrderBooks;

namespace MatchingEngine.Client.Grpc
{
    internal class OrderBooksApi : IOrderBooksApi
    {
        private readonly OrderBooksService.OrderBooksServiceClient _client;

        public OrderBooksApi(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new OrderBooksService.OrderBooksServiceClient(channel);
        }

        public async Task<IReadOnlyList<OrderBookSnapshotModel>> GetAllAsync()
        {
            var orderBooks = new List<OrderBookSnapshotModel>();
            
            try
            {
                using (var streamingCall = _client.OrderBookSnapshots(new Empty()))
                {
                    await foreach (var orderBookSnapshot in streamingCall.ResponseStream.ReadAllAsync())
                    {
                        orderBooks.Add(new OrderBookSnapshotModel(orderBookSnapshot));
                    }
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                // ignore
            }

            return orderBooks;
        }
    }
}