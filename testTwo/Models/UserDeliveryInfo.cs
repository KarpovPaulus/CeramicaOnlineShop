using System.ComponentModel.DataAnnotations;

namespace testTwo.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Нужно указать имя и фамилию")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Нужно указать номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Нужно указать адрес")]
        public string Address { get; set; }
    }
}
