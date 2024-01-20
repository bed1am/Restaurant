using System;
using WpfApp.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Services;
using Interfaces.Services;
using Ninject;
using Test.Utils;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IdishService dishService;
        IOrderService orderService;
        IReportService reportService;
        public MainWindow()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("Model1"));

            dishService = kernel.Get<IdishService>();
            orderService = kernel.Get<IOrderService>();
            reportService = kernel.Get<IReportService>();
            DataContext = new MainViewModel(this,orderService,dishService,reportService);
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
