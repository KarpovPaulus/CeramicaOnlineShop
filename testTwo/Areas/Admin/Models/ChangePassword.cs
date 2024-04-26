using System.ComponentModel.DataAnnotations;

namespace testTwo.Areas.Admin.Models
{
    public class ChangePassword
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Длина пароля от 6, до 25 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
