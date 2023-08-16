using AuctionService.Data.Context;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class BidPlacedConsumer : IConsumer<BidPlaced>
    {
        private readonly AuctionDbContext _dbContext;

        public BidPlacedConsumer(AuctionDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Consume(ConsumeContext<BidPlaced> context)
        {
            var auction = await _dbContext.Auctions.FindAsync(context.Message.AuctionId);
            if (auction.CurrentHighBid == null)
            {

            }
        }
    }
}
