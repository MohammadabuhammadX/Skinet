using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage ="Price must be greater than zero")]
        [Required]
        public decimal Price { get; set; }

        [Range(1, double.MaxValue, ErrorMessage ="Quantity must be at least 1")]
        [Required]
        public int Quantity { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
