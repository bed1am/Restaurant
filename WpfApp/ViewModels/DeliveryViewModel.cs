using BLL.Services;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class DeliveryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        IdishService dishService;
        IOrderService orderService;
        //IPatientService patientService;
        IReportService reportService;
        //IDbCrud context;
        //IComboService comboService;
        //IDoctorService doctorService;
        //IPatientService patientService;
        //IReportService reportService;
        //IVisitService visitService;
        //ISheduleService sheduleService;
        //IFileService fileService;

        private DeliveryWindow mainWindow;
        //private DeliveryWindow _clientWindow;
        private ClientWindow _managerWindow;

        //private RelayComand clientAutCommand;
        //public RelayComand ClientAutCommand
        //{
        //    get
        //    {
        //        return clientAutCommand ??
        //          (clientAutCommand = new RelayComand(obj =>
        //          {
        //              ToClientPage(obj);
        //          }));
        //    }
        //}

        private RelayComand submitCommand;
        public RelayComand SubmitCommand
        {
            get
            {
                return submitCommand ??
                  (submitCommand = new RelayComand(obj =>
                  {
                      ToDeliveryPage(obj);
                  }));
            }
        }

        public DeliveryViewModel(DeliveryWindow mainWindow/*, IDbCrud context, IComboService comboService, IDoctorService doctorService, IPatientService patientService, IReportService reportService, IVisitService visitService, ISheduleService sheduleService, IFileService fileService*/)
        {
            this.mainWindow = mainWindow;
        }

        private void ToDeliveryPage(object obj)
        {
            _managerWindow = new ClientWindow(/*orderService, dishService, reportService*//*context, comboService, patientService, reportService, visitService, sheduleService, fileService*/);
            _managerWindow.Show();
            mainWindow.Close();
        }
    }
}
