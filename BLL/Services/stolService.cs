using BLL.DTO;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class stolService : IstolService
    {
        private Model1 db;
        public stolService()
        {
            db = new Model1();
        }

        public bool MakeStol(stolDto stolDto)
        {
            stol stol = new stol
            {
                id = stolDto.id,
                number_stol = stolDto.number_stol,
                status = stolDto.status,
                


            };
            db.stols.Add(stol);
            if (db.SaveChanges() > 0)
                return true;
            return false;

        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public stolDto GetStol(int Id)
        {
            return new stolDto(db.stols.Find(Id));
        }
        public void CreateStol(stolDto p)
        {
            db.stols.Add(new stol() { id = p.id, number_stol = p.number_stol, status = p.status});
            Save();
        }
        public void UpdateStol(stolDto p)
        {
            stol st = db.stols.Find(p.id);
            st.number_stol = p.number_stol;
            st.status = p.status;
            Save();
        }
        public void DeleteStol(int id)
        {
            stol p = db.stols.Find(id);
            if (p != null)
            {
                db.stols.Remove(p);
                Save();
            }
        }

        public List<stolDto> GetAllStols()
        {
            var res = db.stols.ToList();
            return res.Select(i => new stolDto(i)).ToList();
        }
    }
}
