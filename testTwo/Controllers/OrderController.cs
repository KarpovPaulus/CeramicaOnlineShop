using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using testTwo.Models;

namespace testTwo.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersInMemoryRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersInMemoryRepository;
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            var userCart = cartsRepository.TryGetByUserId(Constants.UserId);
            var order = new Order
            {
                User = user,
                Items = userCart.Items,
            };
            ordersRepository.Add(order);
            cartsRepository.Clear(Constants.UserId);
            return View(userCart);
        }
        public IActionResult Index(string userId)
        {
            return View();
        }
    }
}
