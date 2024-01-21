using BLL.Services;
using Interfaces.Services;
using Ninject;
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
using Test.Utils;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        IdishService dishService;
        IOrderService orderService;
        IReportService reportService;
        IDishStringService dishstringService;
    
        public ClientWindow(/*IOrderService orderService, IdishService dishService, IReportService reportService*//*IOrderService orderService*/)
        {
            InitializeComponent();
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("Model11"));

            dishService = kernel.Get<IdishService>();
            dishstringService = kernel.Get<IDishStringService>();
            orderService = kernel.Get<IOrderService>();
            reportService = kernel.Get<IReportService>();
            DataContext = new ClientViewModel( orderService, dishstringService,dishService,reportService);
            //var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("ProjectSystemContext"));

            //workerService = kernel.Get<IWorkerService>();
            //positionService = kernel.Get<IPositionService>();
            //DataContext = new WorkersVM(workerService, positionService);

        }

       
    }
}
