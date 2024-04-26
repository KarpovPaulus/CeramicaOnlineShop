using System.ComponentModel.DataAnnotations;

namespace testTwo.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите название товара")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите название товара")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage ="Введите описание товара")]
        public string Description { get; set; }
            
        public string ImgePath { get; set; }

        public Product()
        {
            Id = instanceCounter;
            instanceCounter++;
        }
        public Product(string name, int cost, string description, string imgePath): this()
        {

            Name = name;
            Cost = cost;
            Description = description;
            ImgePath = imgePath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
    }
