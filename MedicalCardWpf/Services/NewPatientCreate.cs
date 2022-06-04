using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Services
{
    public static class NewPatientCreate
    {
        public static Patient PatientCreate(string firstName, string surName, DateTime birthday, string address, string phone, byte[] photo)
        {
            return new Patient
            {
                Firstname = firstName,
                Surname = surName,
                Birthday = birthday,
                Adress = address,
                Phone = phone,
                Photo = photo
            };
        }
    }
}
