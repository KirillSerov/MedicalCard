using MedicalCardWpf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardWpf.Database
{
    public class MedicalCardDB : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<VisitToDoctor> VisitsToDoctors { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog=MedicalCardDB;Integrated Security=True");
        }
     
    }
}
