using System;
using MatchingEngine.Client.Contracts.Balances;

namespace MatchingEngine.Client.Models.Balances
{
    /// <summary>
    /// Represents a balance of an asset.
    /// </summary>
    public class BalanceModel
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BalanceModel"/>.
        /// </summary>
        public BalanceModel()
        {
        }
        
        internal BalanceModel(Balance balance, DateTime timestamp)
        {
            AssetId = balance.AssetId;
            Amount = decimal.Parse(balance.Amount);
            Reserved = decimal.Parse(balance.Reserved);
            Timestamp = timestamp;
        }
        
        /// <summary>
        /// The asset id.
        /// </summary>
        public string AssetId { get; set; }

        /// <summary>
        /// The amount of balance.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The amount that currently are reserved.
        /// </summary>
        public decimal Reserved { get; set; }

        /// <summary>
        /// The date and time of balance.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}