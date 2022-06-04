using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Services
{
    public class PatientsDatabaseRepository
    {
        public static IEnumerable<Patient> Get()
        {
            List<Patient> patientsDatabase = new List<Patient>();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                foreach (var item in db.Patients.ToList())
                {
                    patientsDatabase.Add(new Patient
                    {
                        Id = item.Id,
                        Firstname = item.Firstname,
                        Surname = item.Surname,
                        Birthday = item.Birthday,
                        Phone = item.Phone,
                        Adress = item.Adress,
                        Photo = item.Photo,
                    });
                }
            }
            return patientsDatabase;
        }
        public static IEnumerable<Patient> Get(string name)
        {
            name = name.ToLower();
            using (MedicalCardDB db = new MedicalCardDB())
            {
                var patientsFiltered = db.Patients.Where(p => p.Firstname.ToLower().Contains(name) || p.Surname.ToLower().Contains(name)).Select(p => p.Id).ToList();
                List<Patient> patientsDatabase = new List<Patient>();
                foreach (var item in db.Patients.ToList().Where(v => patientsFiltered.Contains(v.Id)))
                {
                    patientsDatabase.Add(new Patient
                    {
                        Id = item.Id,
                        Firstname = item.Firstname,
                        Surname = item.Surname,
                        Birthday = item.Birthday,
                        Phone = item.Phone,
                        Adress = item.Adress
                    });
                }
                return patientsDatabase;
            }
        }
    }
}
