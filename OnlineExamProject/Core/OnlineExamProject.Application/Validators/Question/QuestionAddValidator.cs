using FluentValidation;
using OnlineExamProject.Application.DTOs.Question;
using OnlineExamProject.Application.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Validators.Question
{
    public class QuestionAddValidator : AbstractValidator<VM_QuestionAdd>
    {
        public QuestionAddValidator()
        {
            RuleFor(q => q.QuestionHeader)
                .NotEmpty()
                .NotNull()
                .WithMessage("Soru başlığı boş bırakılamaz!")
                .WithName("Başlık");

            RuleFor(q => q.OptionA)
                .NotEmpty()
                .NotNull()
                .WithMessage("Şık boş bırakılamaz!")
                .WithName("A Şıkkı");


            RuleFor(q => q.OptionB)
             .NotEmpty()
             .NotNull()
             .WithMessage("Şık boş bırakılamaz!")
             .WithName("B Şıkkı");


            RuleFor(q => q.OptionC)
             .NotEmpty()
             .NotNull()
             .WithMessage("Şık boş bırakılamaz!")
             .WithName("C Şıkkı");

            RuleFor(q => q.OptionD)
             .NotEmpty()
             .NotNull()
             .WithMessage("Şık boş bırakılamaz!")
             .WithName("D Şıkkı");

            RuleFor(q => q.AnswerKey)
             .NotEmpty()
             .NotNull()
             .WithMessage("Cevap boş bırakılamaz!")
             .InclusiveBetween(1, 4)
             .WithMessage("Doğru cevap şık numarası 1 ile 4 arasında olmalıdır.");


        }
    }
}
