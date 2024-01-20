using BLL.Services;
using Interfaces.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>().InSingletonScope();
            Bind<IReportService>().To<ReportService>().InSingletonScope();
            Bind<IdishService>().To<dishService>().InSingletonScope();
            Bind<IDishStringService>().To<DishStringService>().InSingletonScope();
            Bind<IstolService>().To<stolService>().InSingletonScope();
        }
    }
}
