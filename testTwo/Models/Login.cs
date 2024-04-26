using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace testTwo.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан логин")]
        [EmailAddress(ErrorMessage = "Логин должен быть почтой")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Длина пароля от 6, до 25 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}