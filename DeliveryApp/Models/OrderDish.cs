using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models
{
    public class OrderDish
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Dish")]
        public int DishId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public string? Image { get; set; }
    }
}
