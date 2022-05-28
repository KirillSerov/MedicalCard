using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            using (MedicalCardDB db = new MedicalCardDB())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

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
                    Photo = File.ReadAllBytes(System.IO.Path.GetFullPath(@"D:\Programming\C#\Step\MedicalCard\MedicalCardWpf\PatientsPhoto\1.jpg"))
                };
                Patient p2 = new Patient
                {
                    Firstname = "Петр",
                    Surname = "Петров",
                    Birthday = new DateTime(1988, 8, 12),
                    Phone = "+555555",
                    Adress = "Russia, 7",
                    Photo = File.ReadAllBytes(System.IO.Path.GetFullPath(@"D:\Programming\C#\Step\MedicalCard\MedicalCardWpf\PatientsPhoto\2.jpg"))
                };
                db.Patients.Add(p1);
                db.Patients.Add(p2);

                VisitToDoctor v1 = new VisitToDoctor(d1, p2, new DateTime(2022, 1, 1), "С животом");
                VisitToDoctor v2 = new VisitToDoctor(d2, p1, new DateTime(2022, 2, 12), "С головой");
                v1.Result = "Попить таблеточки";
                v2.Result = "Поспать";
                db.VisitsToDoctors.Add(v1);
                db.VisitsToDoctors.Add(v2);

                db.SaveChanges();
            }
        }



        private void PatientDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.PatientsDatabase.PatientsDatabase patientsDatabase = new Windows.PatientsDatabase.PatientsDatabase();
            patientsDatabase.ShowDialog();
        }

        private void NewPatientButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DoctorDatabaseButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DoctorEnterButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Menu3.DoctorInfo doctorInfo = new Windows.Menu3.DoctorInfo();
            doctorInfo.ShowDialog();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }


    }
}
