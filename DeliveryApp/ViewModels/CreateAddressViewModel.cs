using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.ViewModels
{
    public class CreateAddressViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите город ресторана")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите улицу ресторана")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Введите дом ресторана")]
        public string House { get; set; }
    }
}
