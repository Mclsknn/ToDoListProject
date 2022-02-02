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
    public class UserManager :IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void AddUser(User us)
        {
            _userDal.Insert(us);
        }
        public void DeleteUser(User us)
        {
            _userDal.Delete(us);
        }
        public List<User> GetAllUser()
        {
            return _userDal.GetListAll();
        }
        public User GetByIDUser(int id)
        {
            return _userDal.GetByID(id);
        }
        public void UpdateUser(User us)
        {
            _userDal.Update(us);
        }
        public User GetUserByMail(string mail) { 
         return _userDal.GetUserByMail(mail);
        }
    }
}
