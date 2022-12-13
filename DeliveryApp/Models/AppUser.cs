using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class AppUser : IdentityUser
    {
        
        public ICollection<Order>? Orders { get; set; }

    
        public string? HomeAddress { get; set; } 
       

        [ForeignKey("Cart")]
        public int CartId { get; set; }
    }
}
