using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<delivery> deliveris { get; }
        IRepository<order> orders { get; }
        IRepository<dish> dishes { get; }
        IRepository<dish_string> dish_strings { get; }
        IRepository<stol> stols { get; }
        IReportsRepository Reports { get; }
        int Save();
    }
}
