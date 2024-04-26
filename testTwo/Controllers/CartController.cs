﻿using Microsoft.AspNetCore.Mvc;

namespace testTwo.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Lower(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.LowerCartProduct(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Up(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.UpCartProduct(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
