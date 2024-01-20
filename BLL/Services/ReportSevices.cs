using DAL;
using DomainModel;
using Interfaces.Services;
using BLL.DTO;
using Interfaces.Repository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces.DTO;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;

        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<SPResult> ExecuteSP(string adress, int numeric, string number)
        {

            return db.Reports.ExecuteSP(adress, numeric,number).Select(i => new SPResult { id = i.id, order_status = i.order_status, summ = i.summ, adress = i.adress, dish = i.dish, delivery_price = i.delivery_price, number_cli = i.number_cli }).ToList();
        }

        public List<ReportData> ReportOrdersWithDelivery(int orderId)
        {
            var request = db.Reports.ReportOrdersWithDelivery(orderId)
             .Select(i => new ReportData() { Dish = i.Dish, Summ = i.Summ, adress = i.adress, id_order = i.id_order, number_cli = i.number_cli })
             .ToList();
            return request;
        }
    }
}
