using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarkBid.Data
{
    [Table("bids")]
    public class Bid
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("auction_id")]
        public int AuctionId { get; set; }

        [Required]
        [Column("amount", TypeName = "decimal(12,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column("bid_time")]
        public DateTime BidTime { get; set; }
    }
}
