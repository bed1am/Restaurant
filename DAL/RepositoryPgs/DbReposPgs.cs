using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class DbReposPgs : IDbRepos
    {
        private Model1 db;
        private DeliveryReposPgs deliveryRepository;
        private DishReposPgs dishRepository;
        private OrderReposPgs orderRepository;
        private DishStringReposPgs dishstringRepository;
        private stolReposPgs stolRepository;
        private ReportReposPgs reportRepository;

        public DbReposPgs()
        {
            db = new Model1();
        }

        public IRepository<delivery> deliveris
        {
            get
            {
                if (deliveryRepository == null)
                    deliveryRepository = new DeliveryReposPgs(db);
                return deliveryRepository;
            }
        }
        public IRepository<stol> stols
        {
            get
            {
                if (stolRepository == null)
                    stolRepository = new stolReposPgs(db);
                return stolRepository;
            }
        }
        public IRepository<dish_string> dish_strings
        {
            get
            {
                if (dishstringRepository == null)
                    dishstringRepository = new DishStringReposPgs(db);
                return dishstringRepository;
            }
        }

        public IRepository<dish> dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishReposPgs(db);
                return dishRepository;
            }
        }

        public IRepository<order> orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderReposPgs(db);
                return orderRepository;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportReposPgs(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
