using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IdishService
    {
        List<dishDto> GetAllDishes();
        dishDto GetDish(int phoneId);
        void CreateDish(dishDto p);
        void UpdateDish(dishDto p);
        void DeleteDish(int id);

        //List<ManufacturerDto> GetManufacturers();
    }
}
