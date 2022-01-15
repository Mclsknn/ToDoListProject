using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IToDoService
    {
         void AddToDo(ToDo td);
         void UpdateToDo(ToDo td);
         void DeleteToDo(ToDo td);
         ToDo GetByIDToDo(int id, int userID);
         List<ToDo> GetAllToDo(int userID);
    }
}
