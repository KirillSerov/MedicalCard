﻿using MedicalCardWpf.Context;
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
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientInfo : Window
    {
        private MedicalCardDB _db;
        private Patient _patient;
        private List<PatientInfoService> patientInfoService;
        public PatientInfo(Patient patient)
        {
            InitializeComponent();
            _patient = patient;
            patientInfoService = new List<PatientInfoService>();
            this.DataContext = _patient;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using(_db = new MedicalCardDB())
            {
                var visits = _db.VisitsToDoctors.Where(v => v.PatientId == _patient.Id).ToList();
                var doctors = _db.Doctors.ToList();
                foreach (var item in visits)
                {
                    patientInfoService.Add(new PatientInfoService { VisitToDoctor = item, Doctor = doctors.FirstOrDefault(d => d.Id == item.DoctorId) });
                }

                PatientInfoGrid.Items.Clear();
                PatientInfoGrid.ItemsSource = patientInfoService;
            }
        }

        private void PatientInfoGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(sender is DataGrid grid && grid.SelectedIndex >= 0)
            {
                if(grid.SelectedItem is PatientInfoService patientInfoService)
                MessageBox.Show(patientInfoService.VisitToDoctor.Result);
            }
        }
    }
}
