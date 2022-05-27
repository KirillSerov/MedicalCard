using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Models
{
    public class VisitToDoctor
    {
        public int Id { get; set; }
        public DateTime? VisitDate { get; set; }
        public string? Problem { get; set; }
        public string? Result { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public VisitToDoctor() { }

        public VisitToDoctor(Doctor doctor, Patient patient, DateTime visitDate, string problem)
        {
            VisitDate = visitDate;
            Doctor = doctor;
            Patient = patient;
            Problem = problem;
        }
    }
}
