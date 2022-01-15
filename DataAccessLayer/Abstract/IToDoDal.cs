using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IToDoDal
    {
        void Insert(ToDo t);
        void Delete(ToDo t);
        void Update(ToDo t);
        List<ToDo> GetListAll();
        ToDo GetByID(Expression<Func<ToDo, bool>> filter);
        List<ToDo> GetListAll(Expression<Func<ToDo, bool>> filter);
    }
}
