using System;
using Com.Lykke.Matching.Engine.Incoming;
using Grpc.Net.Client;

namespace MatchingEngine.Client.Grpc
{
    public class MatchingEngine : IMatchingEngine
    {
        public MatchingEngine(
            string cashServiceHost,
            string tradingServiceHost,
            string orderBooksServiceHost,
            string balancesServiceHost)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            
            var cashServiceChannel = GrpcChannel.ForAddress(cashServiceHost);
            CashService = new CashService.CashServiceClient(cashServiceChannel);

            var tradingServiceChannel = GrpcChannel.ForAddress(tradingServiceHost);
            TradingService = new TradingService.TradingServiceClient(tradingServiceChannel);

            var orderBooksServiceChannel = GrpcChannel.ForAddress(orderBooksServiceHost);
            OrderBooksService = new OrderBooksService.OrderBooksServiceClient(orderBooksServiceChannel);

            var balancesServiceChannel = GrpcChannel.ForAddress(balancesServiceHost);
            BalancesService = new BalancesService.BalancesServiceClient(balancesServiceChannel);
        }

        public CashService.CashServiceClient CashService { get; }
        public TradingService.TradingServiceClient TradingService { get; }
        public OrderBooksService.OrderBooksServiceClient OrderBooksService { get; }
        public BalancesService.BalancesServiceClient BalancesService { get; }
    }
}