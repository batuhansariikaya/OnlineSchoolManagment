using FluentValidation;
using OnlineExamProject.Application.ViewModels.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Validators.Exam
{
    public class UpdateExamValidator : AbstractValidator<VM_UpdateExam>
    {

        public UpdateExamValidator()
        {
            RuleFor(x => x.name).NotEmpty()
                .WithMessage("Lütfen sınav adını boş geçmeyiniz. ")
                .Length(5, 40)
                .WithMessage("Sınav adı minimum 5 maksimum 40 karakterden oluşmalıdır. ")
                .WithName("Sınav Adı");
            RuleFor(x => x.description)
            .NotEmpty()
            .WithMessage("Lütfen sınav açıklamasını boş geçmeyiniz. ")
            .Length(10, 60)
            .WithMessage("Sınav açıklaması minimum 10 maksimum 60 karakterden oluşmalıdır. ")
            .WithName("Açıklama");
            RuleFor(x => x.time)
                .NotEmpty()
                .WithMessage("Lütfen sınav süresini boş geçmeyiniz. ")
                .WithName("Süre");
        }
    }
}
