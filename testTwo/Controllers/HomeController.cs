using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using testTwo.Models;
using System.IO;


namespace testTwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public HomeController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
    }
}
