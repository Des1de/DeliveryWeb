using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class AppUser : IdentityUser
    {
        
        public string? HomeAddress { get; set; } 
       

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart UsersCart { get; set; }
    }
}
