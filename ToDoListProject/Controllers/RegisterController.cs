using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListProject.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<SelectListItem> list = new List<SelectListItem>() {
                new SelectListItem {
                    Text = "Erkek",
                    Value = "Erkek"
                },
                new SelectListItem { 
                    Text= "Kadın",
                    Value= "Kadın"
                }
            };
            ViewBag.cv = list;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(User user)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(user);
            UserManager um = new UserManager(new EFUserRepository());
            User us = um.GetUserByMail(user.UserMail);
            if (results.IsValid && us==null)
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
