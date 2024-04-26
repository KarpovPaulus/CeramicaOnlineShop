using testTwo.Models;

namespace testTwo
{
    public interface IProductsRepository
    {
        List<Product> GetAll();

        Product TryGetById(int id);

        void Add(Product product);
        void Update(Product product);
    }
}
