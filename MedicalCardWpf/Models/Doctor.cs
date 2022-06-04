using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Position { get; set; }

        public Doctor()
        {
            VisitsToDoctors = new List<VisitToDoctor>();
        }

        public List<VisitToDoctor> VisitsToDoctors { get; set; }
        public override string ToString()
        {
            return Position;
        }
    }
}
