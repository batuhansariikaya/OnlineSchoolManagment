using Microsoft.AspNetCore.Identity;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Validators.CustomValidations
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (int.TryParse(user.UserName[0].ToString(), out int _)) //Kullanıcı adının sayısal ifadeyle başlamaması kontrolü
                errors.Add(new IdentityError { Code = "UserNameNumberStartWith", Description = "Kullanıcı adı sayısal ifadeyle başlayamaz..." });
            if (user.UserName.Length < 3 && user.UserName.Length > 25) //Kullanıcı adının 3 ile 25 karakter arasında olması
                errors.Add(new IdentityError { Code = "UserNameLength", Description = "Kullanıcı adı 3 - 15 karakter arasında olmalıdır..." });
            if (user.Email.Length > 70) // Emailin 70 karakterden fazla olmaması kontrolü
                errors.Add(new IdentityError { Code = "EmailLength", Description = "Email 70 karakterden fazla olamaz..." });

            if (!errors.Any())
                return Task.FromResult(IdentityResult.Success);
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }
    }

}    
