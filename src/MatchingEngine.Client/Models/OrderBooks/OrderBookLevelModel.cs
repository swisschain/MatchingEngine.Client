using System;
using MatchingEngine.Client.Contracts.Outgoing;

namespace MatchingEngine.Client.Models.OrderBooks
{
    /// <summary>
    /// Represents an order bool level.
    /// </summary>
    public class OrderBookLevelModel
    {
        /// <summary>
        /// Initializes a new instance of <see cref="OrderBookLevelModel"/>.
        /// </summary>
        public OrderBookLevelModel()
        {
        }

        internal OrderBookLevelModel(OrderBookSnapshot.Types.OrderBookLevel orderBookLevel)
        {
            Price = decimal.Parse(orderBookLevel.Price);
            Volume = decimal.Parse(orderBookLevel.Volume);
            WalletId = Guid.Parse(orderBookLevel.WalletId);
            OrderId = Guid.Parse(orderBookLevel.OrderId);
        }

        /// <summary>
        /// The limit order price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The limit order volume.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// The wallet identifier.
        /// </summary>
        public Guid WalletId { get; set; }

        /// <summary>
        /// The limit order identifier.
        /// </summary>
        public Guid OrderId { get; set; }
    }
}