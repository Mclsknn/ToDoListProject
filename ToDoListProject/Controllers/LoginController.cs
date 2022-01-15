using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject.Controllers
{
    public class LoginController : Controller
    {
        
        Context c = new Context();

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User user)
        {
            
             var datavalue = c.Users.FirstOrDefault(x => x.UserMail == user.UserMail && x.UserPassword == user.UserPassword);
             User kullanici = c.Users.Where(x=> x.UserID == datavalue.UserID).FirstOrDefault();
               if (datavalue != null)
               {
               
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, kullanici.UserName)
                   };
                   string id = kullanici.UserID.ToString();
                   HttpContext.Session.SetString("UserID", id);
                   var useridentity = new ClaimsIdentity(claims, "a");
                   ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                   await HttpContext.SignInAsync(principal);
                   return RedirectToAction("Index", "User");
               }
               else
               {
                   return View();
               }
        }
    }
}
