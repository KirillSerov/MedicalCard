using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.ViewModels
{
    public class PatientInfoContext
    {
        public Doctor Doctor { get; set; }
        public VisitToDoctor VisitToDoctor { get; set; }
    }
}
