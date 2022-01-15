using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        void AddUser(User us);
        void UpdateUser(User us);
        void DeleteUser(User us);
        User GetByIDUser(int id);
        List<User> GetAllUser();
    }
}
