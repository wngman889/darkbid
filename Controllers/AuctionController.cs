using DarkBid.Data;
using DarkBid.Interfaces;
using DarkBid.Services;
using Microsoft.AspNetCore.Mvc;

namespace DarkBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        private readonly ILogger<AuctionService> _logger;
        public AuctionController(IAuctionService auctionService, ILogger<AuctionService> logger)
        {
            _auctionService = auctionService ?? throw new ArgumentNullException(nameof(auctionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("add-auction")]
        public async Task<IActionResult> AddAuction(int productId, string productName, string brand, string category, float price,
                                     float rating, string color, string size, int userId)
        {
            await _auctionService.AddAuction(productId, productName, brand, category, price, rating, color, size, userId);
            return Ok("Auction Created");
        }

        [HttpGet("get-auction")]
        public async Task<IActionResult> GetAuction(int id)
        {
            try
            {
                var result = await _auctionService.GetAuction(id);

                if (result == null)
                {
                    _logger.LogInformation($"Auction with ID {id} not found.");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving auction with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("get-all-auctions")]
        public async Task<IActionResult> GetAuctions()
        {
            try
            {
                var auctions = await _auctionService.GetAuctions();

                if (auctions == null)
                {
                    return NotFound();
                }

                return Ok(auctions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting auction: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update-auction")]
        public async Task<IActionResult> UpdateAuction(int id, int userId)
        {
            try
            {
                var existingAuction = await _auctionService.GetAuction(id);

                if (existingAuction == null)
                {
                    _logger.LogInformation($"Auction with ID {id} not found.");
                    return NotFound();
                }

                await _auctionService.UpdateAuction(id, userId);

                return Ok("Auction Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating auction with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete-auction")]
        public async Task<IActionResult> DeleteAuction(int id)
        {
            try
            {
                var existingAuction = await _auctionService.GetAuction(id);

                if (existingAuction == null)
                {
                    _logger.LogInformation($"Auction with ID {id} not found.");
                    return NotFound();
                }

                await _auctionService.DeleteAuction(id);

                return Ok("Auction Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting auction with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
