using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Database
{
    public static class DatabaseGenerator
    {
        public static void FirstCreate()
        {
            using (MedicalCardDB db = new MedicalCardDB())
            {
                db.Database.EnsureDeleted();
                if (db.Database.EnsureCreated())
                {
                    Doctor d1 = new Doctor { Position = "Педиатр" };
                    Doctor d2 = new Doctor { Position = "Терапевт" };
                    db.Doctors.Add(d1);
                    db.Doctors.Add(d2);

                    Patient p1 = new Patient
                    {
                        Firstname = "Иван",
                        Surname = "Иванов",
                        Birthday = new DateTime(1986, 8, 10),
                        Phone = "+123123",
                        Adress = "Russia, 5",
                        Photo = File.ReadAllBytes(@"D:\Programming\C#\Step\MedicalCard\MedicalCardWpf\PatientsPhoto\1.jpg")
                    };
                    Patient p2 = new Patient
                    {
                        Firstname = "Петр",
                        Surname = "Петров",
                        Birthday = new DateTime(1988, 8, 12),
                        Phone = "+555555",
                        Adress = "Russia, 7",
                        Photo = File.ReadAllBytes(@"D:\Programming\C#\Step\MedicalCard\MedicalCardWpf\PatientsPhoto\2.jpg")
                    };
                    db.Patients.Add(p1);
                    db.Patients.Add(p2);
                    VisitToDoctor v1 = new VisitToDoctor
                    {
                        Doctor = d1,
                        Patient = p2,
                        VisitDate = new DateTime(2022, 1, 1),
                        Problem = "С животом"
                    };
                    VisitToDoctor v2 = new VisitToDoctor
                    {
                        Doctor = d2,
                        Patient = p1,
                        VisitDate = new DateTime(2022, 2, 12),
                        Problem = "С головой"
                    };
                    v1.Result = "Попить таблеточки";
                    v2.Result = "Поспать";
                    db.VisitsToDoctors.Add(v1);
                    db.VisitsToDoctors.Add(v2);

                    db.SaveChanges();
                }
            }
        }
    }
}
