using MedicalCardWpf.Database;
using MedicalCardWpf.Models;
using MedicalCardWpf.Services;
using MedicalCardWpf.ViewModels;
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
    /// Interaction logic for DoctorInfo.xaml
    /// </summary>
    public partial class DoctorInfo : Window
    {
        private readonly Doctor _doctor;
        public DoctorInfo(Doctor doctor)
        {
            if (doctor == null)
                return;
            InitializeComponent();
            _doctor = doctor;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _doctor;
            DoctorInfoGrid.ItemsSource = DoctorInfoRepository.Get(_doctor);
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

        private void DoctorInfoGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid grid && grid.SelectedIndex >= 0)
            {
                if (grid.SelectedItem is DoctorInfoContext doctorInfoContext)
                {
                    string result = doctorInfoContext.VisitToDoctor.Result ?? "";
                    ResultEdit resultEdit = new ResultEdit(result);
                    if (resultEdit.ShowDialog() == true)
                    {
                        using (MedicalCardDB db = new MedicalCardDB())
                        {
                            VisitToDoctor tmp = db.VisitsToDoctors.FirstOrDefault(vd => vd.Id == doctorInfoContext.VisitToDoctor.Id);
                            if (tmp != null)
                            {
                                tmp.Result = resultEdit.Result;
                                db.VisitsToDoctors.Update(tmp);
                                db.SaveChanges();
                            }
                        }
                        DoctorInfoGrid.ItemsSource = DoctorInfoRepository.Get(_doctor);
                    }
                }
            }
        }
    }
}
