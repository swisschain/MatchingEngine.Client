namespace MatchingEngine.Client.Models.Trading
{
    /// <summary>
    /// Specifies limit order status. 
    /// </summary>
    public enum LimitOrderStatus
    {
        Unknown = 0,
        MessageProcessingDisabled = 1,
        Ok = 2,
        LowBalance = 401,
        DisabledAsset = 403,
        UnknownAsset = 410,
        Duplicate = 430,
        BadRequest = 400,
        Runtime = 500,
        Replaced = 421,
        NotFoundPrevious = 422,
        ReservedVolumeHigherThanBalance = 414,
        LimitOrderNotFound = 415,
        BalanceLowerThanReserved = 416,
        LeadToNegativeSpread = 417,
        TooSmallVolume = 418,
        InvalidFee = 419,
        InvalidPrice = 420,
        NoLiquidity = 411,
        NotEnoughFunds = 412,
        InvalidVolumeAccuracy = 431,
        InvalidPriceAccuracy = 432,
        InvalidVolume = 434,
        TooHighPriceDeviation = 435,
        InvalidOrderValue = 436,
        NegativeOverdraftLimit = 433
    }
}