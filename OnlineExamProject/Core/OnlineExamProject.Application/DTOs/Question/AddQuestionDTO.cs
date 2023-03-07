using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.Question
{
    public class AddQuestionDTO
    {
        public string QuestionHeader { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int AnswerKey { get; set; }
        
    }
}
