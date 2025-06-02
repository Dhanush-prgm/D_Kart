using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Kart.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
       [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [Column("price")]
        public decimal Price { get; set; }
        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; }
        [Required]
        [Column("is_added_to_cart")]
        public bool IsAddedToCart { get; set; }
    }

}