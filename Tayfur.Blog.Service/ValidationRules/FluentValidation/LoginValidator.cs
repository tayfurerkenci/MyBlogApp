using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.ValidationRules.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş bırakılamaz!")
                .EmailAddress().WithMessage("E-posta adresi uygun formatta olmalıdır!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz!");
        }
    }
}
