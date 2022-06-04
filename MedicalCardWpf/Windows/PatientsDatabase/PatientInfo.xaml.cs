using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using MedicalCardWpf.Services;
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
using System.Windows.Shapes;

namespace MedicalCardWpf.Windows.PatientsDatabase
{
    /// <summary>
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientInfo : Window
    {
        private Patient _patient;
        public PatientInfo(Patient patient)
        {
            InitializeComponent();
            _patient = patient;
            DataContext = _patient;
            PatientPhoto.Source = Converter(_patient.Photo);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PatientInfoGrid.ItemsSource = await Task.Run(()=>PatientInfoRepository.Get(_patient));
        }

        private BitmapImage Converter(byte[] photo)
        {
            BitmapImage image = new BitmapImage();
            MemoryStream ms = new MemoryStream();
            ms.Write(photo, 0, photo.Length);
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
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
