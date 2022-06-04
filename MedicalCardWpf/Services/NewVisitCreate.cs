using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Services
{
    public static class NewVisitCreate
    {
        public static VisitToDoctor VisitCreate(int doctorId, int patientId, DateTime date, string problem)
        {
            return new VisitToDoctor
            {
                DoctorId = doctorId,
                PatientId = patientId,
                VisitDate = date,
                Problem = problem
            };
        }
    }
}
