using MedicalCardWpf.Database;
using MedicalCardWpf.ViewModels;
using MedicalCardWpf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCardWpf.Services
{
    public static class PatientInfoRepository
    {
        public static IEnumerable<PatientInfoContext> Get(Patient patient)
        {
            if (patient == null)
                return null;
            var patientInfoService = new List<PatientInfoContext>();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                foreach (var item in db.VisitsToDoctors.ToList().Where(v => v.PatientId == patient.Id))
                {
                    patientInfoService.Add(new PatientInfoContext { VisitToDoctor = item, Doctor = db.Doctors.FirstOrDefault(d => d.Id == item.DoctorId) });
                }
            }
            return patientInfoService;
        }
    }
}
