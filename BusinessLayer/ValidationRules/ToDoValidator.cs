using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ToDoValidator : AbstractValidator<ToDo>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.ToDoTitle).NotEmpty()
                .WithMessage("Yapılacak iş kısmı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty()
                .WithMessage("Yapılacak işin açıklama kısmı boş geçilemez");
            RuleFor(x => x.ToDoTitle).MinimumLength(2)
                .WithMessage("Yapılacak iş 2 harf den az olamaz");
            RuleFor(x => x.Description).MinimumLength(2)
                .WithMessage("Açıklama 2 harf den az olamaz");
            RuleFor(x => x.toDoDate).NotEmpty().GreaterThan(DateTime.Now)
           .WithMessage("Geçmiş tarih girilemez");
            
        }
    }
}
