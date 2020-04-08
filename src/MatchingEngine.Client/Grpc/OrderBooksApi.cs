using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using MatchingEngine.Client.Api;
using MatchingEngine.Client.Contracts.Api;
using MatchingEngine.Client.Contracts.Outgoing;

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

        public async Task<IReadOnlyList<OrderBookSnapshot>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orderBooks = new List<OrderBookSnapshot>();
            
            try
            {
                using (var streamingCall = _client.OrderBookSnapshots(new Empty(), cancellationToken: cancellationToken))
                {
                    await foreach (var orderBookSnapshot in streamingCall.ResponseStream.ReadAllAsync(cancellationToken))
                    {
                        orderBooks.Add(orderBookSnapshot);
                    }
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                // ignore
            }

            return orderBooks;
        }

        public async Task<IReadOnlyList<OrderBookSnapshot>> GetAllByBrokerIdAsync(OrderBookSnapshotRequest request, CancellationToken cancellationToken = default)
        {
            var orderBooks = new List<OrderBookSnapshot>();

            try
            {
                using (var streamingCall = _client.BrokerOrderBookSnapshots(request, cancellationToken: cancellationToken))
                {
                    await foreach (var orderBookSnapshot in streamingCall.ResponseStream.ReadAllAsync(cancellationToken))
                    {
                        orderBooks.Add(orderBookSnapshot);
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