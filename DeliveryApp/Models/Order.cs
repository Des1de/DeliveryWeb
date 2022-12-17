using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime dateTime { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        [ForeignKey("Dish")]
        public int? DishId { get; set;}

        [ForeignKey("AppUser")]
        public int? UserId { get; set;}
    }
}
