using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_specialist_article_archiv.Models
{
    public class Archiv
    {
        public int Id { get; set; } 
        public Source Source { get; set; }  
        public Device Device { get; set; }
        public SearchTerm Term { get; set; }  
        public SubjectArea Area { get; set; }
        public Employee Employee { get; set; }
        public DateTime EmployeeDate { get; set; }
        public DateTime Realese { get; set; }   
        public int PageNumber { get; set; }
    }
}
