using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

    }
}
