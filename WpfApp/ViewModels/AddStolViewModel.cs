using BLL.DTO;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    internal class AddStolViewModel : ViewModelBase
    {
        IdishService dishService;
        IOrderService orderService;
        IstolService stolService;
        IReportService reportService;
        private ClientWindow mainWindow;
        private DeliveryWindow _managerWindow;
        private string _number_stol;
        public string NumberStol
        {
            get { return _number_stol; }
            set { _number_stol = value; OnPropertyChanged(); }
        }

        private string _id;
        public string StolId
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        private ObservableCollection<orderDto> _stolDto;

        public ObservableCollection<orderDto> AllStol
        {
            get { return _stolDto; }
            set { _stolDto = value; OnPropertyChanged(); }
        }
        private AddStol AddMenuStol;
        public ICommand AddStol { get; set; }

        public ObservableCollection<dishDto> AllDishes { get; set; }
        public ObservableCollection<deliveryDto> AllDeliveries { get; set; }
        private void AddStolMenu(object obj)
        {
            AddMenuStol = new AddStol(orderService, dishService, stolService, reportService);
            AddMenuStol.ShowDialog();

            AllStol = new ObservableCollection<orderDto>(orderService.GetAllOrders());
        }
        private void AddCommandExecute(object obj)
        {
            try
            {
                stolDto temp = new stolDto();
                temp.id = Int32.Parse(_id);
                temp.number_stol = Int32.Parse(_number_stol);
                //temp.PassportSeries = Int32.Parse(_passport_series);
                //temp.IDPosition = SelectedPosition.Id;
                //temp.Position = SelectedPosition;

                stolService.CreateStol(temp);

                MessageBox.Show("Добавлен стол");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public ICommand AddCommand { get; set; }
        public AddStolViewModel( IOrderService orderService, IdishService dishService, IstolService stolService, IReportService reportService)
        {
            this.dishService = dishService;
            this.orderService = orderService;
            this.stolService = stolService;
            this.reportService = reportService;
            AddCommand = new RelayComand(AddCommandExecute);
            AllDishes = new ObservableCollection<dishDto>();
            AllDeliveries = new ObservableCollection<deliveryDto>();
        }
    }
}
