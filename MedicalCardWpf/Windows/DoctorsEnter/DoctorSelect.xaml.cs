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

namespace MedicalCardWpf.Windows.DoctorsEnter
{
    /// <summary>
    /// Interaction logic for DoctorSelect.xaml
    /// </summary>
    public partial class DoctorSelect : Window
    {
        public DoctorSelect()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoctorsComboBox.ItemsSource = await Task.Run(() => DoctorsDatabaseRepository.Get());
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

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorsComboBox.SelectedItem == null)
                return;
            Doctor doc = DoctorsComboBox.SelectedItem as Doctor;
            if (doc == null)
                return;
            DoctorInfo doctorInfo = new DoctorInfo(doc);
            doctorInfo.Show();
            this.Close();
        }
    }
}
