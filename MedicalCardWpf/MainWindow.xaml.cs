using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using MedicalCardWpf.Windows.DoctorsEnter;
using MedicalCardWpf.Windows.NewPatientMenu;
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
            DatabaseGenerator.FirstCreate();
        }
        
        private void PatientDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.PatientsDatabase.PatientsDatabase patientsDatabase = new Windows.PatientsDatabase.PatientsDatabase();
            patientsDatabase.ShowDialog();
        }

        private void NewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            NewPatient newPatient = new NewPatient();
            newPatient.ShowDialog();
        }

        private void DoctorEnterButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorSelect doctorSelect = new DoctorSelect();
            doctorSelect.ShowDialog();
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

