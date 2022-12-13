using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }    

        public string? Description { get; set; } 

        public int Price { get; set; }  

        public string? Image { get; set; } 
    }
}
