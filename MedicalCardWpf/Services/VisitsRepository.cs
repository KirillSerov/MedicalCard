using MedicalCardWpf.Database;
using MedicalCardWpf.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Services
{
    public static class VisitsRepository
    {
        public static IEnumerable<VisitInfoContext> Get()
        {
            using (MedicalCardDB db = new MedicalCardDB())
            {
                List<VisitInfoContext> vsitsInfoService = new List<VisitInfoContext>();
                foreach (var item in db.VisitsToDoctors.ToList())
                {
                    vsitsInfoService.Add(new VisitInfoContext { VisitToDoctor = item, Doctor = db.Doctors.FirstOrDefault(d => d.Id == item.DoctorId), Patient = db.Patients.FirstOrDefault(p => p.Id == item.PatientId) });
                }
                return vsitsInfoService;
            }
        }

        public static IEnumerable<VisitInfoContext> Get(string name)
        {
            name = name.ToLower();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                var patientsFiltered = db.Patients.Where(p => p.Firstname.ToLower().Contains(name) || p.Surname.ToLower().Contains(name)).Select(p => p.Id).ToList();
                List<VisitInfoContext> patientInfoService = new List<VisitInfoContext>();
                foreach (var item in db.VisitsToDoctors.ToList().Where(v => patientsFiltered.Contains(v.PatientId)))
                {
                    patientInfoService.Add(new VisitInfoContext { VisitToDoctor = item, Doctor = db.Doctors.FirstOrDefault(d => d.Id == item.DoctorId), Patient = db.Patients.FirstOrDefault(p => p.Id == item.PatientId) });
                }
                return patientInfoService;
            }
        }
    }
}
