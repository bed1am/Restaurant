using BLL.DTO;
using BLL.Services;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        IdishService dishService;
        IOrderService orderService;
        IReportService reportService;
        IDishStringService dishstringService;
        private ClientWindow mainWindow;
        private DeliveryWindow _managerWindow;
        public ICommand CatalogCommand { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }

        }
        private int _number;
        public int number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged(); }

        }
        private void Catalog(object obj) => CurrentView = new CatalogViewModel(IdUser,orderService, dishstringService, dishService, reportService);
        private RelayComand deliveryAutCommand;
        public RelayComand DeliveryAutCommand
        {
            get
            {
                return deliveryAutCommand ??
                  (deliveryAutCommand = new RelayComand(obj =>
                  {
                      ToDeliveryPage(obj);
                  }));
            }
        }        
        private RelayComand makeOrder;
        public RelayComand MakeOrder
        {
            get
            {
                return makeOrder ??
                  (makeOrder = new RelayComand(obj =>
                  {
                      orderService.MakeOrder();
                  }));
            }
        }
        private ObservableCollection<orderDto> _orderDto;

        public ObservableCollection<orderDto> AllOrders
        {
            get { return _orderDto; }
            set { _orderDto = value; OnPropertyChanged(); }
        }
        public ObservableCollection<dishDto> OrderedDishes;
        public ObservableCollection<dishDto> orderedDishes { get 
            {
                return OrderedDishes;
            } 
            set 
            {
                OrderedDishes = value;
            } 
        }
        public ObservableCollection<dishDto> AllDishes { get; set; }
        public ObservableCollection<deliveryDto> AllDeliveries { get; set; }
        private ObservableCollection<dishDto> _dish;
        public ObservableCollection<dishDto> Dishes
        {
            get { return _dish; }
            set { _dish = value; OnPropertyChanged(); }
        }

        private dishDto _dishSelected;
        public dishDto dishSelected
        {
            get { return _dishSelected; }
            set { _dishSelected = value; OnPropertyChanged(); }
        }
        private RelayComand addInCart;
        public RelayComand AddInCart
        {
            get
            {
                return addInCart ??
                  (addInCart = new RelayComand(obj =>
                  {
                      AddInCartExecute(obj);
                  }));
            }
        }
        public void AddInCartExecute(object obj)
        {
            if (dishSelected != null)
            {
                dishstringService.PutToBusketDishString(dishSelected, 1);
                orderedDishes.Add(dishSelected);
            }
        }

        public ClientViewModel( IOrderService orderService, IDishStringService dishstringService, IdishService dishService, IReportService reportService)
        {
            this.dishstringService = dishstringService;
            this.dishService = dishService;
            this.orderService = orderService;
            this.reportService = reportService;
            AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
            orderedDishes = new ObservableCollection<dishDto>(dishstringService.GetBusketDishString().Select(i => i.Value));
            CatalogCommand = new RelayComand(Catalog);
            IdUser = 1;
            number = 0;

            Dishes = new ObservableCollection<dishDto>(dishService.GetAllDishes());
            CurrentView = new CatalogViewModel(IdUser, orderService, dishstringService, dishService, reportService);
            AllDishes = new ObservableCollection<dishDto>();
            AllDeliveries = new ObservableCollection<deliveryDto>();
        }
       
        private void ToDeliveryPage(object obj)
        {
            _managerWindow = new DeliveryWindow();
            _managerWindow.Show();
            mainWindow.Close();
        }
    }
}

