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
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {
        public DeliveryWindow()
        {
            InitializeComponent();
            DataContext = new DeliveryViewModel(this/*, dbCrud, comboService, doctorService, patientService, reportService, visitService, sheduleService, fileService*/);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
