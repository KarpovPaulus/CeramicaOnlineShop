using Microsoft.AspNetCore.Mvc;
using testTwo.Areas.Admin.Models;
using testTwo.Models;

namespace testTwo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            var userAccounts = usersManager.GetAll();
            return View(userAccounts);
        }
        public IActionResult Details(string name)
        {
            var userAccount = usersManager.TryGetByName(name);
            return View(userAccount);
        }
        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name,
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if(changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
            if(ModelState.IsValid)
            {
                usersManager.ChangePassword(changePassword.UserName, changePassword.Password);
                var list = usersManager.GetAll();
                return RedirectToAction(nameof(Index));
            }
            return View(changePassword);
        }
    }
}
