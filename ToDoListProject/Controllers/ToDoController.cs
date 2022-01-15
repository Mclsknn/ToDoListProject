using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace ToDoListProject.Controllers
{   [Authorize]
    public class ToDoController : Controller
    {

        ToDoManager tm = new ToDoManager(new EFToDoRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            string s = HttpContext.Session.GetString("UserID");
            int id = Convert.ToInt32(s);
            var values = tm.GetAllToDo(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddToDo() {
            return View();
        }
        [HttpPost]
        public IActionResult AddToDo(ToDo todo)
        {
            ToDoValidator tv = new ToDoValidator();
            ValidationResult results = tv.Validate(todo);

            if (todo.ToDoID != 0)
            {
                if (results.IsValid)
                {
                    todo.UserID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                    tm.UpdateToDo(todo);
                    return RedirectToAction("Index", "ToDo");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            if (results.IsValid)
            {
                todo.UserID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                tm.AddToDo(todo);
                return RedirectToAction("Index", "ToDo");
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
        public IActionResult DoneToDo(int id) {
            ToDo toDo = c.ToDos.Where(x => x.ToDoID == id).FirstOrDefault();
            toDo.IsDone = true;
            tm.UpdateToDo(toDo);
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult UpdateToDo(int id) {
            var value = c.ToDos.Where(x => x.ToDoID == id).FirstOrDefault();
            return View(value);
        }

        public IActionResult DeleteToDo(int id)
        {
            var value = c.ToDos.Where(x => x.ToDoID == id).FirstOrDefault();
            tm.DeleteToDo(value);
            return RedirectToAction("Index");
        }
    }
}
