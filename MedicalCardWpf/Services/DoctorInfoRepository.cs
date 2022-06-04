using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using MedicalCardWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Services
{
    public class DoctorInfoRepository
    {
        public static IEnumerable<DoctorInfoContext> Get(Doctor doctor)
        {
            List<DoctorInfoContext> context = new List<DoctorInfoContext>();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                var visitsToDoctor = db.VisitsToDoctors.Where(v => v.DoctorId == doctor.Id).ToList();
                foreach (var item in visitsToDoctor)
                {
                    context.Add(new DoctorInfoContext { VisitToDoctor = item, Patient = db.Patients.FirstOrDefault(p => p.Id == item.PatientId) });
                }
            }
            return context;
        }

    }
}
