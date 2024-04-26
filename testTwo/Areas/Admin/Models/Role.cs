using System.ComponentModel.DataAnnotations;

namespace testTwo.Areas.Admin.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
