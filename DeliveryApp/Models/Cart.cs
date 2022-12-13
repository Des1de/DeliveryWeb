using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Dish>? Dishes { get; set; }
    }
}
