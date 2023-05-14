using CompanyAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.BAL.Mangers.DepartementManger
{
    public interface IDepartementManager
    {
        public Task<IEnumerable<Departement>>  getAllDepartements();

        public Task<Departement> GetDepartementById(int id);

        public Task addDepartement(Departement departement);

        public Task updateDepartement(Departement departement);

        public Task deleteDepartement (int id);

        public Task saveChanges();
    }
}
