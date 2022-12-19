using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class CartDish
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Dish")]
        public int DishId { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set;}
    }
}
