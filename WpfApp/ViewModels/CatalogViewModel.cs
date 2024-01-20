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

        


        public CatalogViewModel(int IdUserInput, IOrderService orderService, IDishStringService dishstringService, IdishService dishService, IReportService reportService)
        {
            this.dishService = dishService;
            this.orderService = orderService;
            this.dishstringService = dishstringService;
            this.reportService = reportService;
            //IdUser = IdUserInput;

            //AddInCart = new RelayComand(AddInCartExecute);
            //Dishes = new ObservableCollection<dishDto>(dishService.GetAllDishes());

        }
    }
}
