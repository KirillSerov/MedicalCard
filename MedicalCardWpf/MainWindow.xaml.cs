using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalCardWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //using (MedicalCardDB db = new MedicalCardDB())
            //{
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();

            //    Doctor d1 = new Doctor { Position = "Педиатр1" };
            //    Doctor d2 = new Doctor { Position = "Педиатр2" };
            //    db.Doctors.Add(d1);
            //    db.Doctors.Add(d2);

            //    Patient p1 = new Patient { Firstname = "Пациент1", Surname = "Нулевой1", Birthday = new DateTime(1986, 8, 10), Phone = "+123123", Adress = "Russia, 5" };
            //    Patient p2 = new Patient { Firstname = "Пациент2", Surname = "Нулевой2", Birthday = new DateTime(1988, 8, 12), Phone = "+555555", Adress = "Russia, 7" };
            //    db.Patients.Add(p1);
            //    db.Patients.Add(p2);

            //    VisitToDoctor v1 = new VisitToDoctor(d1, p2, new DateTime(2022, 1, 1));
            //    VisitToDoctor v2 = new VisitToDoctor(d2, p1, new DateTime(2022, 2, 12));
            //    v1.Result = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBkkkkkkkkkkkkkkkkkkkkkkkkkkkk";
            //    db.VisitsToDoctors.Add(v1);
            //    db.VisitsToDoctors.Add(v2);

            //    db.SaveChanges();
            //}
        }



        private void PatientsRecords_Click(object sender, RoutedEventArgs e)
        {
            Windows.Menu1.VisitsRecords patientsRecords = new Windows.Menu1.VisitsRecords();
            patientsRecords.Owner = this;
            patientsRecords.ShowDialog();
        }

        private void NewRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DoctorEnter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
