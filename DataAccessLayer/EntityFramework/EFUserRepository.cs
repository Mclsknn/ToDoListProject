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
    public class EFUserRepository : IUserDal
    {
        public void Delete(User user)
        {
            using var c = new Context();
            c.Remove(user);
            c.SaveChanges();
        }
        public User GetByID(int id)
        {
            using var c = new Context();
            return c.Set<User>().Find(id);
        }
        public List<User> GetListAll()
        {
            using var c = new Context();
            return c.Set<User>().ToList();
        }
        public void Insert(User user)
        {
            using var c = new Context();
            c.Add(user);
            c.SaveChanges();
        }
        public List<User> GetListAll(Expression<Func<User, bool>> filter)
        {
            using var c = new Context();
            return c.Set<User>().Where(filter).ToList();
        }
        public void Update(User user)
        {
            using var c = new Context();
            c.Update(user);
            c.SaveChanges();
        }
        public User GetUserByMail(string mail)
        {
            using var c = new Context();
            return c.Set<User>().Where(x=> x.UserMail == mail).FirstOrDefault();
        }
    }
}
