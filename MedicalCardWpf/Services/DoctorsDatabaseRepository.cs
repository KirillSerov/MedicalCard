using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Services
{
    public class DoctorsDatabaseRepository
    {
        public static IEnumerable<Doctor> Get()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                foreach (var doctor in db.Doctors)
                {
                    doctors.Add(new Doctor
                    {
                        Id = doctor.Id,
                        Position = doctor.Position,
                    });
                }
            }
            return doctors;
        }
    }
}
