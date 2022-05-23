using MedicalCardWpf.Database;
using MedicalCardWpf.DataContext;
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

namespace MedicalCardWpf.Windows.Menu1
{
    /// <summary>
    /// Interaction logic for PatientsRecords.xaml
    /// </summary>
    public partial class VisitsRecords : Window
    {
        public VisitsRecords()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VisitsRecordsGrid.ItemsSource = VisitsRepository.Get();
        }

        private void PatientsRecordsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid grid && grid.SelectedIndex >= 0)
            {
                var tmp = grid.SelectedValue as VisitInfoContext;
                if (tmp == null)
                    return;
                PatientInfo patientInfo = new PatientInfo(tmp.Patient);
                patientInfo.ShowDialog();
            }
        }

        private void PatientFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
                VisitsRecordsGrid.ItemsSource = VisitsRepository.Get(textBox.Text);
        }
    }
}
