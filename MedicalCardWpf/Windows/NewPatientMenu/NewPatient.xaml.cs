using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using MedicalCardWpf.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace MedicalCardWpf.Windows.NewPatientMenu
{
    /// <summary>
    /// Interaction logic for NewPatient.xaml
    /// </summary>
    public partial class NewPatient : Window
    {
        private string _filename;
        public NewPatient()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<CheckBox> checkBox = new List<CheckBox>();
            IEnumerable<Doctor> doctors = await Task.Run(() => DoctorsDatabaseRepository.Get());
            foreach (Doctor doctor in doctors)
            {
                checkBox.Add(new CheckBox());
                checkBox.Last().Content = doctor;
            }
            DoctorsList.ItemsSource = checkBox;

            DateBirthPicker.DisplayDateEnd = DateTime.Now;
            SelectVisitDate.DisplayDateStart = DateTime.Now;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл фото (.jpg, .png) | *.jpg;*.png";
            openFileDialog.Title = "Загрузка фото";
            if (openFileDialog.ShowDialog() == true)
            {
                _filename = openFileDialog.FileName;
            }
        }

        private void SaveNewPatient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstnameTextBox.Text) || string.IsNullOrWhiteSpace(SurnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProblemTextBox.Text) || string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text))
                return;
            if (!DateTime.TryParse(DateBirthPicker.Text, out DateTime birthDate) || birthDate.Date >= DateTime.Now.Date
                || !DateTime.TryParse(SelectVisitDate.Text, out DateTime visitDate))
                return;

            List<Doctor> selectedDoctors = new List<Doctor>();
            bool doctorIsSelected = false;
            foreach (var doc in DoctorsList.ItemsSource)
            {
                if (doc is CheckBox checkBox)
                    if (checkBox.IsChecked ?? false)
                    {
                        selectedDoctors.Add(checkBox.Content as Doctor);
                        doctorIsSelected = true;
                    }
            }
            if (!doctorIsSelected)
                return;

            Patient newPatient = NewPatientCreate.PatientCreate(FirstnameTextBox.Text, SurnameTextBox.Text, birthDate, AddressTextBox.Text,
                PhoneTextBox.Text, File.ReadAllBytes(_filename));

            using (MedicalCardDB db = new MedicalCardDB())
            {
                db.Patients.Add(newPatient);
                db.SaveChanges();
            }

            List<VisitToDoctor> visits = new List<VisitToDoctor>();
            foreach (var doc in selectedDoctors)
            {
                visits.Add(NewVisitCreate.VisitCreate(doc.Id, newPatient.Id, visitDate, ProblemTextBox.Text));
            }

            using (MedicalCardDB db = new MedicalCardDB())
            {
                db.VisitsToDoctors.AddRange(visits);
                db.SaveChanges();
            }

            Close();
        }

        private void PhoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void SelectVisitDate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
