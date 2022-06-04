using MedicalCardWpf.Database;
using MedicalCardWpf.ViewModels;
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
            List<VisitInfoContext> visitsInfoService = new List<VisitInfoContext>();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                foreach (var item in db.VisitsToDoctors.ToList())
                {
                    visitsInfoService.Add(new VisitInfoContext { VisitToDoctor = item, Doctor = db.Doctors.FirstOrDefault(d => d.Id == item.DoctorId), Patient = db.Patients.FirstOrDefault(p => p.Id == item.PatientId) });
                }
            }
            return visitsInfoService;
        }

        public static IEnumerable<VisitInfoContext> Get(string name)
        {
            List<VisitInfoContext> patientInfoService = new List<VisitInfoContext>();
            name = name.ToLower();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                var patientsFiltered = db.Patients.Where(p => p.Firstname.ToLower().Contains(name) || p.Surname.ToLower().Contains(name)).Select(p => p.Id).ToList();
                
                foreach (var item in db.VisitsToDoctors.ToList().Where(v => patientsFiltered.Contains(v.PatientId)))
                {
                    patientInfoService.Add(new VisitInfoContext
                    {
                        VisitToDoctor = item,
                        Doctor = db.Doctors.FirstOrDefault(d => d.Id == item.DoctorId),
                        Patient = db.Patients.FirstOrDefault(p => p.Id == item.PatientId)
                    });
                }
               
            }
            return patientInfoService;
        }
    }
}
