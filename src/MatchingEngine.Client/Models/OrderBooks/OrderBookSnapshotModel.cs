using System;
using System.Collections.Generic;
using System.Linq;
using MatchingEngine.Client.Contracts.Outgoing;

namespace MatchingEngine.Client.Models.OrderBooks
{
    /// <summary>
    /// Represents an order book snapshot.
    /// </summary>
    public class OrderBookSnapshotModel
    {
        /// <summary>
        /// Initializes a new instance of <see cref="OrderBookSnapshotModel"/>.
        /// </summary>
        public OrderBookSnapshotModel()
        {
        }

        internal OrderBookSnapshotModel(OrderBookSnapshot orderBookSnapshot)
        {
            AssetPairId = orderBookSnapshot.Asset;
            IsBuy = orderBookSnapshot.IsBuy;
            Timestamp = orderBookSnapshot.Timestamp.ToDateTime();
            Levels = orderBookSnapshot.Levels
                .Select(level => new OrderBookLevelModel())
                .ToList();
        }

        /// <summary>
        /// The asset pair identifier.
        /// </summary>
        public string AssetPairId { get; set; }

        /// <summary>
        /// Indicates buy side of order books.
        /// </summary>
        public bool IsBuy { get; set; }

        /// <summary>
        /// The date and time of creation.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// A collection of order book levels.
        /// </summary>
        public IReadOnlyList<OrderBookLevelModel> Levels { get; set; }
    }
}