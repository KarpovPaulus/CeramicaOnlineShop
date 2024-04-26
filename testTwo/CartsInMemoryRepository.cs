using testTwo.Models;

namespace testTwo
{
    public class CartsInMemoryRepository : ICartsRepository
    {
        public List<Cart> carts = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(c => c.UserId == userId);
        }

        public void LowerCartProduct(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingCartItem.Amount >= 1)
            {
                existingCartItem.Amount--;
            }
            if(existingCartItem.Amount <= 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }
        }
        public void UpCartProduct(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            existingCartItem.Amount++;
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product,
                        }
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x=>x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product,
                    });
                }
            }
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            carts.Remove(existingCart);
        }
    }
}
