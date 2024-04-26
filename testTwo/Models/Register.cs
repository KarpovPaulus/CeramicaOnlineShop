using System.ComponentModel.DataAnnotations;

namespace testTwo.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан логин")]
        [EmailAddress(ErrorMessage = "Логин должен быть почтой")]
        public string UserName { get; set; }
        [Required]
        public string Phone {  get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Длина пароля от 6, до 25 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
