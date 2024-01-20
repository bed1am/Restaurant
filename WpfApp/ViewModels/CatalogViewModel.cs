using BLL.DTO;
using BLL.Services;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    internal class CatalogViewModel : ViewModelBase
    {
        IdishService dishService;
        IOrderService orderService;
        IReportService reportService;
        IDishStringService dishstringService;

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
        public ICommand AddInCart { get; set; }
        public void AddInCartExecute(object obj)
        {
            if (dishSelected != null)
            {
                dishstringService.PutToBusketDishString(dishSelected, number);
            }
        }


        public CatalogViewModel(int IdUserInput, IOrderService orderService, IDishStringService dishstringService, IdishService dishService, IReportService reportService)
        {
            this.dishService = dishService;
            this.orderService = orderService;
            this.dishstringService = dishstringService;
            this.reportService = reportService;
            IdUser = IdUserInput;

            AddInCart = new RelayComand(AddInCartExecute);
            Dishes = new ObservableCollection<dishDto>(dishService.GetAllDishes());

        }
    }
}
