using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDo : IEntity
    {
        [Key]
        public int ToDoID { get; set; }
        public string ToDoTitle { get; set; }
        public string Description { get; set; }
        public DateTime toDoDate { get; set; }
        public bool IsDone { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }

    }
}
