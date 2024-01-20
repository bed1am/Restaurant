using BLL.DTO;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IDishStringService
    {
        List<dishstringDto> GetAllDishString();
        dishstringDto GetDishString(int phoneId);
        void CreateDishString(dishDto p,int id_order, int number);
        void PutToBusketDishString(dishDto p, int number);
        List<KeyValuePair<int, dishDto>> GetBusketDishString();
        void ClearBusketDishString();
        void UpdateDishString(dishstringDto p);
        void DeleteDishString(int id);
    }
}
