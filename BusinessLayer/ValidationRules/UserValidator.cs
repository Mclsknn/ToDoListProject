using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserGender).NotEmpty()
                .WithMessage("Kullanıcı cinsiyet kısmı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty()
                .WithMessage("Kullanıcı ismi boş geçilemez");
            RuleFor(x => x.UserLastName).NotEmpty()
                .WithMessage("Kullanıcı soy ismi boş geçilemez");
            RuleFor(x => x.UserAddress).NotEmpty()
                .WithMessage("Kullanıcı adres kısmı boş geçilemez");
            RuleFor(x => x.UserPhone).NotEmpty()
                .WithMessage("Kullanıcı telefon numarası kısmı boş geçilemez");
            RuleFor(x => x.UserMail).NotEmpty()
                .WithMessage("Kullanıcı mail kısmı boş geçilemez").EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
            RuleFor(x => x.UserName).MinimumLength(2)
                .WithMessage("Kullanıcı ismi 2 harf den az olamaz");
            RuleFor(x => x.UserLastName).MinimumLength(2)
                .WithMessage("Kullanıcı soyismi 2 harf den az olamaz");
            RuleFor(x => x.UserAddress).MinimumLength(3)
                .WithMessage("Adres 15 harf den az olamaz");
            
        }
    }
}
