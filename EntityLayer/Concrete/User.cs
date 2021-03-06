using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public DateTime UserBirthDate { get; set; }
        public string UserAddress { get; set; }
        public string UserGender { get; set; }
        public List<ToDo> toDos { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }

    }
}
