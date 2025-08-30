using DarkBid.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DarkBid.Interfaces
{
    public interface IAuctionService
    {
        public Task<bool> AddAuction(int productId, string productName, string brand, string category, float price,
                                     float rating, string color, string size, int userId);

        public Task<Auction?> GetAuction(int id);

        public Task<IEnumerable<Auction>?> GetAuctions();

        public Task<bool> UpdateAuction(int id, int userId);

        public Task<bool> DeleteAuction(int id);
    }
}
