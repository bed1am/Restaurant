using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Interfaces.DTO;

namespace Interfaces.Repository
{
    public interface IReportsRepository
    {
        List<SPResult> ExecuteSP(string adress, int numeric, string number);
        List<ReportData> ReportOrdersWithDelivery(int manufId);
    }
}
