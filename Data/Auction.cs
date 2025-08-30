using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarkBid.Data
{
    [Table("auction")]
    public class Auction
    {
        [Key]
        [Column("productId")]
        public int ProductId { get; set; }

        [Column("productName")]
        [MaxLength(255)]
        public string? ProductName { get; set; }

        [Column("brand")]
        [MaxLength(255)]
        public string? Brand { get; set; }

        [Column("category")]
        public string? Category { get; set; }

        [Column("price")]
        public float? Price { get; set; }

        [Column("rating")]
        public float? Rating { get; set; }

        [Column("color")]
        public string? Color { get; set; }

        [Column("size")]
        public string? Size { get; set; }

        [Column("userId")]
        public int? UserId { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }
    }
}
