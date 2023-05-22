using CompanyAPI.DAL.Interfaces;
using CompanyAPI.DAL.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.BAL.Mangers.DepartementManger
{
    public class DepartementManager : IDepartementManager
    {
        private readonly IContextRepo<Departement> departementRepo;

        public DepartementManager(IContextRepo<Departement> _departementRepo)
        {
            departementRepo = _departementRepo;
        }


        public async Task addDepartement(Departement departement)
        {
            await departementRepo.addItem(departement);
        }

        public async Task deleteDepartement(int id)
        {
            await departementRepo.deleteItem(id);
        }

        public async Task<IEnumerable<Departement>> getAllDepartements()
        {
            return await departementRepo.getAll();
        }

        public async Task<Departement> GetDepartementById(int id)
        {
            return await departementRepo.getItemById(id);
        }

       

        public async Task saveChanges()
        {
            await departementRepo.saveChanges();
        }

        public async Task updateDepartement(Departement departement)
        {
            await departementRepo.updateItem(departement);
        }
    }
}
