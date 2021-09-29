using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.ValidationRules.FluentValidation
{
    public class ArticleValidator : AbstractValidator<ArticleViewModel>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Makale adı boş bırakılamaz!");
            RuleFor(x => x.Context)
                .NotEmpty().WithMessage("Makale içeriği boş bırakılamaz!")
                .MinimumLength(50).WithMessage("Makale içeriği 50 karakterden az olmamalıdır!");
        }
    }
}
