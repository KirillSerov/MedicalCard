using MedicalCardWpf.Models;
using MedicalCardWpf.Services;
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
using System.Windows.Shapes;

namespace MedicalCardWpf.Windows.PatientsDatabase
{
    /// <summary>
    /// Interaction logic for PatientsDatabase.xaml
    /// </summary>
    public partial class PatientsDatabase : Window
    {
        public PatientsDatabase()
        {
            InitializeComponent();

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PatientsDatabaseGrid.ItemsSource = await Task.Run(() => PatientsDatabaseRepository.Get());
        }

        private void PatientFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
                PatientsDatabaseGrid.ItemsSource = PatientsDatabaseRepository.Get(textBox.Text);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void PatientsDatabaseGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (sender is DataGrid grid && grid.SelectedIndex >= 0)
            {
                if (grid.SelectedItem is Patient patient)
                {
                    PatientInfo patientInfo = new PatientInfo(patient);
                    patientInfo.ShowDialog();
                }
            }
        }


    }
}
