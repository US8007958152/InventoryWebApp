using InventoryWebApp.BusinessLogicLayer;
using InventoryWebApp.Common;
using InventoryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApp.Controllers
{
    public class SecurityController : Controller
    {
        private IUser _User;

        public SecurityController(IUser user)
        {
            _User = user;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            bool isExists=_User.GetUser(user);
            if (isExists)
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "UserProfile", user);
                return RedirectToAction("GetProducts", "Products");
            }
               
            return View();
        }

    }
}
