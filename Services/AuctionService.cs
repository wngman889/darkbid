using DarkBid.Data;
using DarkBid.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DarkBid.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly DarkBidContext _dbContext;

        private readonly ILogger<AuctionService> _logger;

        public AuctionService(DarkBidContext dbContext, ILogger<AuctionService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddAuction(int productId, string productName, string brand, string category, float price,
                                     float rating, string color, string size, int userId)
        {
            if (string.IsNullOrEmpty(productName))
            {
                _logger.LogError("Invalid input parameters for adding an auction");
                return false;
            }

            try
            {
                var user = await _dbContext.Users.FindAsync(userId);

                if (category == null || user == null)
                    return false;

                var newAuction = new Auction
                {
                    ProductId = productId,
                    ProductName = productName,
                    Brand = brand,
                    Category = category,
                    Price = price,
                    Rating = rating,
                    Color = color,
                    Size = size,
                    UserId = userId
                };


                _dbContext.Auctions.Add(newAuction);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding event to the database");
                return false;
            }
        }

        public async Task<Auction?> GetAuction(int id)
        {
            try
            {
                var auctionFromDB = await _dbContext.Auctions.FindAsync(id);
                return auctionFromDB;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while searching for events");
                return null;
            }
        }

        public async Task<IEnumerable<Auction>?> GetAuctions()
        {
            try
            {
                var auctions = await _dbContext.Auctions.ToListAsync();
                return auctions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting the events");
                return null;
            }
        }

        public async Task<bool> UpdateAuction(int id, int userId)
        {
            var existingAuction = await _dbContext.Auctions.FindAsync(id);

            if (existingAuction == null)
                return false;

            existingAuction.UserId = userId;

            // Apply other update logic based on your requirements

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAuction(int id)
        {
            var existingAuction = await _dbContext.Auctions.FindAsync(id);

            if (existingAuction == null)
                return false;

            _dbContext.Auctions.Remove(existingAuction);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
