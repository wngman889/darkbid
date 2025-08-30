using System.ComponentModel.DataAnnotations.Schema;

namespace RealDarkBid.Models
{
    [Table("auction")]
    public class Auction
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Brand { get; set; }

        public string? Category { get; set; }

        public float? Price { get; set; }

        public float? Rating { get; set; }

        public string? Color { get; set; }

        public string? Size { get; set; }

        public int? UserId { get; set; }

        public string? ImageUrl { get; set; }
    }
}
