using Com.Lykke.Matching.Engine.Incoming;

namespace MatchingEngine.Client.Grpc
{
    public interface IMatchingEngine
    {
        CashService.CashServiceClient CashService { get; }

        TradingService.TradingServiceClient TradingService { get; }

        OrderBooksService.OrderBooksServiceClient OrderBooksService { get; }
    }
}