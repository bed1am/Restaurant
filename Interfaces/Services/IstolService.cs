using BLL.DTO;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IstolService
    {
        List<stolDto> GetAllStols();
        stolDto GetStol(int phoneId);
        void CreateStol(stolDto p);
        void UpdateStol(stolDto p);
        void DeleteStol(int id);
    }
}
