using OnlineExamProject.Domain.Entities.Common;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Domain.Entities
{
	public class Exam:BaseEntity
	{
	
		public string Name { get; set; }
		public string Description { get; set; }
		public string Time { get; set; }
		public int UserId { get; set; }
		public AppUser AppUser { get; set; }
		public ICollection<Question> Questions { get; set; }
		public Grade Grade { get; set; }

		// bir user birden fazla sınavın hocası olabilir

        // exam ile question arasında ilişki  bir sınavın birden çok sorusu olabilir 
        // dependent 




        // hoca ile exam arasında     ilişki  bir hoca birden fazla ders verebilir.
        /*public ICollection<Question> Question { get; set; }
			public int TeacherId { get; set; }
			public Teacher Teacher { get; set; }
		 */
    }
}
