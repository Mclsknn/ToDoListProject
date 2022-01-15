using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFToDoRepository : IToDoDal
    {
        public void Delete(ToDo toDo)
        {
            using var c = new Context();
            c.Remove(toDo);
            c.SaveChanges();
        }

        public ToDo GetByID(Expression<Func<ToDo, bool>> filter)
        {
            using var c = new Context();
            return c.Set<ToDo>().Where(filter).FirstOrDefault();
        }

        public List<ToDo> GetListAll()
        {
            using var c = new Context();
            return c.Set<ToDo>().ToList();
        }

        public void Insert(ToDo toDo)
        {
            using var c = new Context();
            c.Add(toDo);
            c.SaveChanges();
        }
        public List<ToDo> GetListAll(Expression<Func<ToDo, bool>> filter)
        {
            using var c = new Context();
            return c.Set<ToDo>().Where(filter).ToList();
        }

        public void Update(ToDo toDo)
        {
            using var c = new Context();
            c.Update(toDo);
            c.SaveChanges();
        }
    }
}
