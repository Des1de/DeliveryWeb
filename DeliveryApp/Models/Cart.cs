using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public List<CartDish> CartDishes { get; set; }
    }
}
