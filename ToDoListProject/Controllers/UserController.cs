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

namespace ToDoListProject.Controllers
{
    public class UserController : Controller
    {
        Context c = new Context();
        UserManager um = new UserManager(new EFUserRepository());
        public IActionResult Index()
        {
            string s = HttpContext.Session.GetString("UserID");
            int id = Convert.ToInt32(s);
            var value = um.GetByIDUser(id);
            return View(value);
        }

        public IActionResult AddUser(User user) {

            UserValidator uv = new UserValidator();
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
    }
}
