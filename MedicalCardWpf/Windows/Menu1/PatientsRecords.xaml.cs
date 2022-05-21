using MedicalCardWpf.Context;
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
using System.Windows.Shapes;

namespace MedicalCardWpf.Windows.Menu1
{
    /// <summary>
    /// Interaction logic for PatientsRecords.xaml
    /// </summary>
    public partial class PatientsRecords : Window
    {
        private MedicalCardDB db;
        public PatientsRecords()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (db = new MedicalCardDB())
            {
                var patients = db.Patients.ToList();
                PatientsRecordsGrid.Items.Clear();
                PatientsRecordsGrid.ItemsSource = patients;
            }
        }

        private void PatientsRecordsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           if(sender is DataGrid grid && grid.SelectedIndex >= 0)
            {
                PatientInfo patientInfo = new PatientInfo(grid.SelectedValue as Patient);
                patientInfo.Owner = this;
                patientInfo.ShowDialog();
            }
        }
    }
}
