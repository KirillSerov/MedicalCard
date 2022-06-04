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
    /// Interaction logic for ResultEdit.xaml
    /// </summary>
    public partial class ResultEdit : Window
    {
        public ResultEdit(string result)
        {
            InitializeComponent();
            Result = result;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = Result;
        }
        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            Result = ResultTextBox.Text;
            this.DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }

        public string Result { get; private set; }
    }
}
