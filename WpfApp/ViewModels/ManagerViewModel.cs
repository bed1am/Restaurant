using BLL.DTO;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    internal class ManagerViewModel : ViewModelBase
    {
        IdishService dishService;
        IOrderService orderService;
        IstolService stolService;
        IReportService reportService;
        private ClientWindow mainWindow;
        private DeliveryWindow _managerWindow;
        private ObservableCollection<orderDto> _orderDto;

        public ObservableCollection<orderDto> AllOrders
        {
            get { return _orderDto; }
            set { _orderDto = value; OnPropertyChanged(); }
        }
        private orderDto _selectedOrder;
        public orderDto SelectedOrder
        {
            get { return _selectedOrder; }
            set { _selectedOrder = value; OnPropertyChanged(); }

        }
        private ObservableCollection<stolDto> _stolDto;

        public ObservableCollection<stolDto> AllStol
        {
            get { return _stolDto; }
            set { _stolDto = value; OnPropertyChanged(); }
        }
        private stolDto _selectedStol;
        public stolDto SelectedStol
        {
            get { return _selectedStol; }
            set { _selectedStol = value; OnPropertyChanged(); }

        }
        private AddOrder AddMenuOrder;
        private AddStol AddMenuStol;
        public ICommand AddOrder { get; set; }
        public ICommand DeleteOrder { get; set; }
        public ICommand UpdateOrder { get; set; }
        public ICommand AddStol { get; set; }
        public ICommand DeleteStol { get; set; }
        public ICommand UpdateStol { get; set; }

        public ObservableCollection<dishDto> AllDishes { get; set; }
        public ObservableCollection<deliveryDto> AllDeliveries { get; set; }

        private void AddStolMenu(object obj)
        {
            AddMenuStol = new AddStol(orderService, dishService, stolService, reportService);
            AddMenuStol.ShowDialog();

            AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
        }
        private void DeleteOrderExecute(object obj)
        {
            try
            {
                orderService.DeleteOrder(SelectedOrder.id);
                AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateOrderExexute(object obj)
        {
            foreach (orderDto order in AllOrders)
            {
                orderService.UpdateOrder(order);
            }
        }
        private void DeleteStolExecute(object obj)
        {
            try
            {
                stolService.DeleteStol(SelectedStol.id);
                AllStol = new ObservableCollection<stolDto>(stolService.GetAllStols());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStolExexute(object obj)
        {
            foreach (stolDto order in AllStol)
            {
                stolService.UpdateStol(order);
            }
        }

        public ManagerViewModel(IOrderService orderService, IdishService dishService, IstolService stolService, IReportService reportService)
        {
            this.dishService = dishService;
            this.orderService = orderService;
            this.stolService = stolService;
            this.reportService = reportService;
            AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
            AllStol = new ObservableCollection<stolDto>(stolService.GetAllStols());
            AllDishes = new ObservableCollection<dishDto>();
            AllDeliveries = new ObservableCollection<deliveryDto>();
            DeleteOrder = new RelayComand(DeleteOrderExecute);
            UpdateOrder = new RelayComand(UpdateOrderExexute);
            AddStol = new RelayComand(AddStolMenu);
            DeleteStol = new RelayComand(DeleteStolExecute);
            UpdateStol = new RelayComand(UpdateStolExexute);
        }
    }
}
