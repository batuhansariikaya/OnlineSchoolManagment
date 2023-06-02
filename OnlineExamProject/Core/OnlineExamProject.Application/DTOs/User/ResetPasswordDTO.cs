using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.User
{
    public class ResetPasswordDTO
    {   
        public string Email { get; set; }       
    }
}
