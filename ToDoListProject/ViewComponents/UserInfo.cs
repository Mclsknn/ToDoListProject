using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using EntityLayer.Concrete;

namespace ToDoListProject.ViewComponents
{
    public class UserInfo : ViewComponent
    {
        UserManager bm = new UserManager(new EFUserRepository());
        public IViewComponentResult Invoke()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            User user = bm.GetByIDUser(id);
            ViewBag.v1 = user.UserName;
            ViewBag.v2 = user.UserLastName;
            return View();
        }
    }
}
