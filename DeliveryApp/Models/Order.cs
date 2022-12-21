using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

      

        public int TotalPrice { get; set; } 

        [ForeignKey("Address")]
        public int? AddressId { get; set; }


        public List<OrderDish> OrderDishes { get; set; }

        [ForeignKey("AppUser")]
        public int? UserId { get; set;}
    }
}
