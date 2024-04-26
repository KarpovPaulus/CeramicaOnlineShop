using testTwo.Models;
using System.Linq;

namespace testTwo
{
    public class ProductsInMemoryRepository : IProductsRepository
    {

        private List<Product> products = new List<Product>
        {
            new Product("Чашка", 120, "Чашка для кофе", "/imges/1.jpeg"),
            new Product("Тарелка", 140, "Тарелка для супа", "/imges/2.jpeg"),
            new Product("Блюдце", 100, "Блюдце для кружки", "/imges/3.jpeg"),
            new Product("Графин", 200, "Графин для воды", "/imges/4.jpeg"),
            new Product("Подставка", 150, "Подставка для графина", "/imges/5.jpeg")
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(products => products.Id == id);
        }
        public void Add(Product product)
        {
            product.ImgePath = "/imges/1.jpeg";
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(x=>x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
        }
    }
}
