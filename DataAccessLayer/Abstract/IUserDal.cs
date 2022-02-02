using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal
    {
        void Insert(User u);
        void Delete(User u);
        void Update(User u);
        List<User> GetListAll();
        User GetByID(int id);
        List<User> GetListAll(Expression<Func<User, bool>> filter);
        User GetUserByMail(string mail);
    }
}
