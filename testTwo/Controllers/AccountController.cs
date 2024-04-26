using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using testTwo.Models;

namespace testTwo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;

        public AccountController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if(!ModelState.IsValid)
                return View(login);

            var userAccount = usersManager.TryGetByName(login.UserName);
            if(userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует");
                return RedirectToAction(nameof(Login));
            }
            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Не правильный пароль");
                return RedirectToAction(nameof(Login));
            }
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    Name = register.UserName,
                    Password = register.Password,
                    Phone = register.Phone
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View("Register", register);
        }
    }
}
