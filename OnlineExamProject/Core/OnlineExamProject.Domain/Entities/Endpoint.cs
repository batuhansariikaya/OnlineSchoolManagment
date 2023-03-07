using OnlineExamProject.Domain.Entities.Common;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Domain.Entities
{
    public class Endpoint:BaseEntity
    {
        public Endpoint()
        {
            Roles = new HashSet<AppRole>();
        }
        public string Name { get; set; }
        public string HttpType { get; set; }
        public string ActionType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public ICollection<AppRole> Roles { get; set; }

    }
}
