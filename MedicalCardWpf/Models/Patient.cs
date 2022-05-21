using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }

        public Patient()
        {
            VisitsToDoctors = new List<VisitToDoctor>();
        }

        public List<VisitToDoctor> VisitsToDoctors { get; set; }
    }
}
