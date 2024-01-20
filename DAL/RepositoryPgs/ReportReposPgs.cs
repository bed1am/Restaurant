using DomainModel;
using Interfaces.Repository;
using Interfaces.DTO;
//using BLL.DTO;
//using Interfaces.Repository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class ReportReposPgs : IReportsRepository
    {
        private Model1 db;
        public ReportReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<SPResult> ExecuteSP(string adress, int numeric, string number)
        {
            Model1 db = new Model1();
            NpgsqlParameter param1 = new NpgsqlParameter("@adress", adress);
            NpgsqlParameter param2 = new NpgsqlParameter("@valueord", numeric);
            NpgsqlParameter param3 = new NpgsqlParameter("@number", number);
            NpgsqlParameter param4 = new NpgsqlParameter("@price", 500);
            NpgsqlParameter param5 = new NpgsqlParameter("@id_del", (int)db.deliveries.Max(x => x.id) + 1);
            var result = db.Database.SqlQuery<SPResult>("select * from new_delivery(@adress,@valueord,@number,@price,@id_del)", new object[] { param1, param2, param3, param4, param5 }).ToList();
            return result;
        }

        public List<ReportData> ReportOrdersWithDelivery(int orderId)
        {
            Model1 db = new Model1();
            var request = db.orders
            .Join(db.deliveries, ph => ph.id, m => m.id_order, (ph, m) => new {
                dish = ph.dish,
                summ = ph.summ,
                adress = m.adress,
                //new_summ = m.delivery_price + ph.summ,
                id_order = m.id_order,
                number_cli = m.number_cli
            })
            .Where(i => i.id_order == orderId/*numericUpDown1.Value*/)
            .Select(i => new ReportData() { Dish = i.dish, Summ = i.summ, adress = i.adress, /*New_summ = i.summ,*/ id_order = i.id_order, number_cli = i.number_cli })
            .ToList();
            return request;
        }
    }
}
