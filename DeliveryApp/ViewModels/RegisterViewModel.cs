using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Подтвердите пароль")]
        [Required(ErrorMessage = "Нужно подтвердить пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Введите номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Адрес проживания")]
        [Required(ErrorMessage = "Введите адрес вашего проживания")]
        public string HomeAddress { get; set; }
    }
}
