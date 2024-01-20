using BLL.Services;
using Interfaces.Services;
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
    /// Логика взаимодействия для AddStol.xaml
    /// </summary>
    public partial class AddStol : Window
    {
        public AddStol(IOrderService orderService, IdishService dishService, IstolService stolService, IReportService reportService)
        {
            InitializeComponent();
            DataContext = new AddStolViewModel(/*this,*/ orderService, dishService, stolService, reportService);
        }

        
    }
}
