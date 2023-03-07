using FluentValidation;
using OnlineExamProject.Application.DTOs.Grade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Validators.Grade
{
    public class GradeAddValidator:AbstractValidator<GradeAddDTO>
    {
        public GradeAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Sınıf Adı Boş Olamaz!").WithName("Sınıf Adı");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Sınıf Kodu Boş Olamaz!").WithName("Sınıf Kodu");
           
        }
    }
}
