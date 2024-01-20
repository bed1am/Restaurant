using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IReportService
    {
        List<SPResult> ExecuteSP(string adress, int numeric, string number);
        List<ReportData> ReportOrdersWithDelivery(int manufId);
    }
}
