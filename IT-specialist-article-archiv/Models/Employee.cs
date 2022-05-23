using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_specialist_article_archiv.Models
{
    public class Employee
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Housenumber { get; set; } 
        public string Street { get; set; }  
        public string City { get; set; }
        public long Postcode { get; set; }   
        public long Phonnumber { get; set; }
        public string Email { get; set; }   
    }
}
