using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
namespace ToDoListProject.Controllers
{
    public class UserController : Controller
    {
        Context c = new Context();
        UserManager um = new UserManager(new EFUserRepository());
        UserValidator uv = new UserValidator();
      

        public IActionResult Index()
        {
            string s = HttpContext.Session.GetString("UserID");
            int id = Convert.ToInt32(s);
            var value = um.GetByIDUser(id);
            List<SelectListItem> gender = new List<SelectListItem>{
               new SelectListItem
               {
                 Text = "Erkek",
                 Value = "Erkek",
               },
               new SelectListItem {
                 Text = "Kadın",
                 Value = "Kadın",
               }
            };
            ViewBag.c = gender;
            return View(value);
        }

        public IActionResult AddUser(User user) {

            ValidationResult results = uv.Validate(user);

            if (results.IsValid)
            {
                um.AddUser(user);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult EditUser(User user) {

            ValidationResult results = uv.Validate(user);
            string s = HttpContext.Session.GetString("UserID");
            int id = Convert.ToInt32(s);
            user.UserID = id;
            if (results.IsValid)
            {   
                um.UpdateUser(user);
                return RedirectToAction("Index", "User");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return new EmptyResult();
        }

        public async Task<IActionResult> DeleteUser(int id) {
            User user = um.GetByIDUser(id);
            um.DeleteUser(user);
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
            
        }

        [HttpGet]
        public IActionResult UserChangePassword()
        {
            string s = HttpContext.Session.GetString("UserID");
            int id = Convert.ToInt32(s);
            User user = um.GetByIDUser(id);
            return View(user); 
        }
        [HttpPost]
        public IActionResult ChangePassword(string password) {
            string s = HttpContext.Session.GetString("UserID");
            int id = Convert.ToInt32(s);
            User user = um.GetByIDUser(id);
            user.UserPassword = password;
            um.UpdateUser(user);
            var jso = JsonConvert.SerializeObject(user);
            return RedirectToAction("Index","User");
        }
    }
}
