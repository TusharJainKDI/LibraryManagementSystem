using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
namespace LibraryManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountRepo _accountRepo;
        public LoginController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }


        public IActionResult Index(string username, string password)
        {
            
            if(username != null && password != null)
            {
                HttpContext.Session.SetString("Uname", username);
                var user = _accountRepo.getUserByName(username);
                if(user== null)
                {
                    ViewBag.Message = "Invalid Credentials. User null";
                }
                else if (username.Equals("admin") && password.Equals("admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (username.Equals(user.UserName) && password.Equals(user.Password))
                {
                    return RedirectToAction("Index", "User");                    
                }
                else
                {
                    ViewBag.Message = "Invalid Credentials!! Please Try Again";
                }
            }
            return View();
        }
    }
}
