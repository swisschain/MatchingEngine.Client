using System;

namespace MatchingEngine.Client.Models.Trading
{
    /// <summary>
    /// Represents limit order creation response.
    /// </summary>
    public class LimitOrderResponseModel
    {
        /// <summary>
        /// Initializes a new instance of <see cref="LimitOrderResponseModel"/>.
        /// </summary>
        public LimitOrderResponseModel()
        {
        }

        internal LimitOrderResponseModel(Contracts.Incoming.Response response)
        {
            Id = Guid.Parse(response.Id);
            Status = Enum.Parse<LimitOrderStatus>(response.Status.ToString());
            Reason = response.StatusReason;
        }

        /// <summary>
        /// The unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The limit order status.
        /// </summary>
        public LimitOrderStatus Status { get; set; }

        /// <summary>
        /// The error status message.
        /// </summary>
        public string Reason { get; set; }
    }
}