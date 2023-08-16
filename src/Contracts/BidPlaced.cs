﻿namespace Contracts
{
    public class BidPlaced
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public string Bidder { get; set; }
        public int Amount { get; set; }
        public DateTime BidTime { get; set; }
        public string BidStatus { get; set; }
    }
}
