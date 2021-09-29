using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş bırakılamaz!");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Kategori açıklaması boş bırakılamaz!");
        }
    }
}
