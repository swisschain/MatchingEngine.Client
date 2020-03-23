using System;

namespace MatchingEngine.Client.Models.Trading
{
    /// <summary>
    /// Represents limit order creation information.
    /// </summary>
    public class LimitOrderRequestModel
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The asset pair identifier.
        /// </summary>
        public string AssetPairId { get; set; }
        
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
        public string WalletId { get; set; }

        /// <summary>
        /// If <c>true</c> previously created limit orders will be closed.
        /// </summary>
        public bool CancelAllPreviousLimitOrders { get; set; }

        /// <summary>
        /// The date and time of creation.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}