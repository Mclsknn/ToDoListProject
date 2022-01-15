using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;
        public ToDoManager(IToDoDal toDoDal)
        {
            _toDoDal = toDoDal;
        }
        public void AddToDo(ToDo td)
        {
            _toDoDal.Insert(td);
        }

        public void DeleteToDo(ToDo td)
        {
            _toDoDal.Delete(td);
        }

        public List<ToDo> GetAllToDo(int userID)
        {
            return _toDoDal.GetListAll(x=> x.UserID == userID);
        }

        public ToDo GetByIDToDo(int id, int userID)
        {
            return _toDoDal.GetByID(x => x.UserID == userID && x.ToDoID == id);
        }

        public void UpdateToDo(ToDo td)
        {
            _toDoDal.Update(td);
        }
    }
}
