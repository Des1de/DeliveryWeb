using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

      
        public string DeliveryAddress { get; set; }
        public string RestarauntAddress { get; set; }
        public int TotalPrice { get; set; } 

        [ForeignKey("Address")]
        public int? AddressId { get; set; }



        [ForeignKey("AppUser")]
        public string UserId { get; set;}

    }
}
