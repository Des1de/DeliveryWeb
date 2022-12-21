using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeliveryApp.ViewModels
{
    public class EditProfileViewModel
    {

        [DisplayName("Домашний Адрес")]
        public string? HomeAddress { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public string? PhoneNumber { get; set; }
    }
}
