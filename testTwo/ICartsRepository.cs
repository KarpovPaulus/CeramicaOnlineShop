using testTwo.Models;

namespace testTwo
{
    public interface ICartsRepository
    {
        void Clear(string userId);
        void LowerCartProduct(Product product, string userId);
        public Cart TryGetByUserId(string userId);
        void UpCartProduct(Product product, string userId);
        internal void Add(Product product, string userId);
    }
}
