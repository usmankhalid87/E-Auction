using AuctionService.Data.Context;
using AuctionService.Utils.Enums;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class AuctionFinishedComsumer : IConsumer<AuctionFinished>
    {
        private readonly AuctionDbContext _dbContext;

        public AuctionFinishedComsumer(AuctionDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            var auction = await _dbContext.Auctions.FindAsync(context.Message.AuctionId);

            if(context.Message.ItemSold)
            {
                auction.Winner = context.Message.Winner;
                auction.SoldAmount = context.Message.Amount;
            }

            auction.Status = context.Message.Amount > auction.ReservePrice ? Status.Finished : Status.ReserveNotMet;
            await _dbContext.SaveChangesAsync();
        }
    }
}
